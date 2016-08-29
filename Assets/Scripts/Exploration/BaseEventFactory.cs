using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEventFactory
{
    public List<ExplorationEvent> explorationEvents = new List<ExplorationEvent>();

    public abstract void Init();

    public ExplorationEvent getEvent(WorldState ws)
    {
        if (explorationEvents.Count == 0)
        {
            Init();
        }
        for (int tries = 0; tries < 50; tries++)
        {
            int index = Random.Range(0, explorationEvents.Count);
            ExplorationEvent e = explorationEvents[index];
            if (e.precondition.check(ws)) return e;
        }

        Debug.Log("This is highly improbable");
        return null;
    }

    protected ExplorationEvent animalBabyFightMother(SpeciesFactory.Species species)
    {
        return animalBabyFightMother(species, null);
    }

    protected ExplorationEvent animalBabyFightMother(SpeciesFactory.Species species, string trumpOption)
    {
        ExplorationEvent e = new ExplorationEvent();

        AnimalDef animalReward = AnimalDefFactory.CreateDefForSpecies(species);

        e.description = "You come across a baby " + species.ToString() + ", its mother is nearby.";
        e.options = new List<ExplorationEvent.Option>();

        List<AnimalDef> twoAnimals = new List<AnimalDef>() { animalReward, animalReward };

        int fightScore = animalReward.GetAttributeScore(TraitFactory.Attribute.Fighting.ToString());
        int trackingScore = animalReward.GetAttributeScore(TraitFactory.Attribute.Tracking.ToString());

        List<ExplorationCriteria> variableAnimalReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), int.MinValue, fightScore * 2, new RewardImpl.RandomAnimalPenalty("The mother " + species.ToString() + " slaughters one of your animals before retreting to safety with her baby.")),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 2, fightScore * 2 + 1, new RewardImpl.DoNothingReward("The " + species.ToString() + " looks kinda scary, and you back off.")),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 2 + 1, fightScore * 4, new RewardImpl.AnimalReward (animalReward, "You feel great about killing a mother " + species.ToString() + " and enslaving her child")),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 4, int.MaxValue, new RewardImpl.AnimalReward (twoAnimals, "You defeat the mother " + species.ToString() + " and notice another second baby hiding behind her corpse.  You capture 2 baby " + species.ToString()))
        };

        List<ExplorationCriteria> variableTrackingReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, trackingScore, new RewardImpl.RandomAnimalPenalty("You're not very quiet, but don't have to run faster than the " + species.ToString() + ".  You just have to run faster than the slowest animal in your party.")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore, trackingScore * 2, new RewardImpl.DoNothingReward("You escape.")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 2, trackingScore * 4, new RewardImpl.FoodReward(animalReward.GetAttributeScore(TraitFactory.Attribute.Food.ToString()), "After you escape you find " + animalReward.GetAttributeScore(TraitFactory.Attribute.Food.ToString()) + " food with your keen tracking skills")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString(), trackingScore * 4, int.MaxValue, new RewardImpl.AnimalReward (animalReward, "You manage to grab the baby " + species.ToString() + " as you walk away without the mother even noticing"))
        };


        e.options.Add(new ExplorationEvent.Option("Grab it.  You are not afraid of a mama " + species.ToString() + ".", variableAnimalReward));
        e.options.Add(new ExplorationEvent.Option("Walk away quietly.", variableTrackingReward));

        if (trumpOption != null) {
            e.options.Add(
                new ExplorationEvent.Option("Because you have " + trumpOption + ", you can scare the mom away.", TraitFactory.Attribute.Fighting.ToString(), 0, new RewardImpl.AnimalReward(animalReward), new RewardImpl.DoNothingReward("Nothing interesting happens."), new List<string>() { trumpOption }));
        }

        return e;
    }

	protected ExplorationEvent rescueFromQuicksand(SpeciesFactory.Species species, int numAttackers=1) {
		ExplorationEvent e = new ExplorationEvent();

		AnimalDef animalReward = AnimalDefFactory.CreateDefForSpecies(species);

		int foodReward = animalReward.GetAttributeScore(TraitFactory.Attribute.Food.ToString()) * numAttackers;

		string foodString = "";
		if (numAttackers == 1) {
			e.description = "You see a " + species.ToString() + " trapped in the quicksand";
			foodString = "You rescued the " + species.ToString() + " and harvest its meat to feed your animals";
		} else {
			e.description = "You see " + numAttackers + " " + species.ToString() + " trapped in the quicksand";
			foodString = "You killed every last " + species.ToString() + " and make a meal of their corpses.  you collect a feast of " + foodReward + " food.";
		}

		string tameString = "";
		if (numAttackers == 1) {
			e.description = "You see a " + species.ToString() + " trapped in the quicksand";
			tameString = "You rescued the " + species.ToString() + " and it joins you.";
		} else {
			e.description = "You see " + numAttackers + " " + species.ToString() + " trapped in the quicksand";
			tameString = "You rescued every last " + species.ToString() + " and they join you.";
		}

		e.options = new List<ExplorationEvent.Option>();

		int trackingScore = Mathf.FloorToInt( animalReward.GetAttributeScore(TraitFactory.Attribute.Tracking.ToString()) * (0.5f + numAttackers));
		//int trackingScore = animalReward.GetAttributeScore(TraitFactory.Attribute.Tracking.ToString());


		List<ExplorationCriteria> variableFoodReward = new List<ExplorationCriteria>() {
			new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, trackingScore * 2, new RewardImpl.RandomAnimalPenalty()),
			new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 2, trackingScore * 2 + 3, new RewardImpl.FoodPenalty(25,
				"The quicksand nearly killed you and claimed some of your supplies.  You lost 25 food.")),
			new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 2 + 3, int.MaxValue, new RewardImpl.FoodReward(foodReward, foodString))
		};

		List<ExplorationCriteria> variableRescueReward = new List<ExplorationCriteria>() {
			new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, trackingScore * 3, new RewardImpl.RandomAnimalPenalty()),
			new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 3, trackingScore * 3 + 3, new RewardImpl.FoodPenalty(25,
				"The quicksand nearly killed you and claimed some of your supplies.  You lost 25 food.")),
			new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 3 + 3, int.MaxValue, new RewardImpl.AnimalReward(animalReward, tameString))
		};


		e.options.Add(new ExplorationEvent.Option("Your animals are hungry.  Let's try to get some meat.", variableFoodReward));
		e.options.Add(new ExplorationEvent.Option("The " + species.ToString() + " look like great new travel companions. Maybe if we rescue them, they will join our cause?", variableRescueReward));
		e.options.Add(new ExplorationEvent.Option("Do Nothing.", 
			new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, int.MaxValue, new RewardImpl.DoNothingReward())
		));

		return e;
	}

    protected ExplorationEvent attackedBy(SpeciesFactory.Species species, int numAttackers)
    {
        return attackedBy(species, numAttackers, null);
    }

    protected ExplorationEvent attackedBy(SpeciesFactory.Species species, int numAttackers, string trumpOption)
    {
        ExplorationEvent e = new ExplorationEvent();

        AnimalDef animalReward = AnimalDefFactory.CreateDefForSpecies(species);

        int foodReward = animalReward.GetAttributeScore(TraitFactory.Attribute.Food.ToString()) * numAttackers;

        string foodString = "";
        if (numAttackers == 1) {
            e.description = "You are attacked by a wild " + species.ToString();
            foodString = "You killed the " + species.ToString() + " and harvest its meat to feed your animals";
        } else {
            e.description = "You are attacked by a pack of " + numAttackers + " wild " + species.ToString();
            foodString = "You killed every last " + species.ToString() + " and make a meal of their corpses.  you collect a feast of " + foodReward + " food.";
        }

        e.options = new List<ExplorationEvent.Option>();

        int fightScore = Mathf.FloorToInt( animalReward.GetAttributeScore(TraitFactory.Attribute.Fighting.ToString()) * (0.5f + numAttackers));
        int trackingScore = animalReward.GetAttributeScore(TraitFactory.Attribute.Tracking.ToString());



        List<ExplorationCriteria> variableAnimalReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), int.MinValue, fightScore * 2, new RewardImpl.RandomAnimalPenalty("The pack of wild " + species.ToString() + " tear one of your animals apart.")),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 2, fightScore * 2 + 3, new RewardImpl.FoodPenalty(25,
                "The " + species.ToString() + " nearly killed you.  Before you dealt the winning blow it tore into your pack and scatterd your suppplies.  You lost 25 food.")),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 2 + 3, int.MaxValue, new RewardImpl.FoodReward(foodReward, foodString))
        };

        List<ExplorationCriteria> variableTrackingReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, trackingScore, new RewardImpl.RandomAnimalPenalty("You did not run faster than the pack of wild " + species.ToString() +".")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore, trackingScore * 2,
                new RewardImpl.FoodPenalty(animalReward.GetAttributeScore(TraitFactory.Attribute.Food.ToString()), "You drop some of your supplies as you run.  You lose " + animalReward.GetAttributeScore(TraitFactory.Attribute.Food.ToString()) + " food")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString(), trackingScore * 2, int.MaxValue, new RewardImpl.DoNothingReward("You escape without losing any of your animals"))
        };


        e.options.Add(new ExplorationEvent.Option("Stand your ground.", variableAnimalReward));
        e.options.Add(new ExplorationEvent.Option("Run like the wind.", variableTrackingReward));

        if (trumpOption != null)
        {
            e.options.Add(
                new ExplorationEvent.Option("Lucky for you, " + species.ToString() + " are afraid of " + trumpOption + ", you can scare them away.", TraitFactory.Attribute.Fighting.ToString(), 0, new RewardImpl.AnimalReward(animalReward), new RewardImpl.DoNothingReward("Nothing interesting happens."), new List<string>() { trumpOption }));
        }

        return e;
    }

    protected ExplorationEvent babyInATree(SpeciesFactory.Species species)
    {
        ExplorationEvent e = new ExplorationEvent();

        AnimalDef animalReward = AnimalDefFactory.CreateDefForSpecies(species);

        e.description = "You come across a baby " + species.ToString() + " in a tree.";
        e.options = new List<ExplorationEvent.Option>();

        List<AnimalDef> twoAnimals = new List<AnimalDef>() { animalReward, animalReward };

        int trackingScore = animalReward.GetAttributeScore(TraitFactory.Attribute.Tracking.ToString());

        List<ExplorationCriteria> variableAnimalReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, trackingScore, new RewardImpl.RandomAnimalPenalty("You discover that falling from a tree can be fatal.")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore, trackingScore * 2, new RewardImpl.DoNothingReward("You can't reach it.")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 2 , trackingScore * 5, new RewardImpl.AnimalReward (animalReward, "You 'rescue' the baby " + species.ToString() + ".  It will never have suffer the pains of freedom again.")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 5 , int.MaxValue, new RewardImpl.AnimalReward (twoAnimals, "There were 2 of them up there.  You capture 2 baby " + species.ToString() + "."))
        };

        e.options.Add(new ExplorationEvent.Option("Attempt to climb the tree to get it.", variableAnimalReward));
        e.options.Add(new ExplorationEvent.Option("Walk away.", TraitFactory.Attribute.Tracking.ToString(), 0, new RewardImpl.DoNothingReward("You walk away."), new RewardImpl.DoNothingReward("You walk away.")));
        e.options.Add(
            new ExplorationEvent.Option("Send your climbing creature after it.", TraitFactory.Attribute.Tracking.ToString(), 0, new RewardImpl.AnimalReward(animalReward, "Your climbing creature brings the baby " + species.ToString() + " down from the tree"), new RewardImpl.AnimalReward(animalReward), new List<string>() { TraitFactory.Traits.Climb.ToString() }));
        e.options.Add(
            new ExplorationEvent.Option("Send your flying creature after it.", TraitFactory.Attribute.Tracking.ToString(), 0, new RewardImpl.AnimalReward(animalReward, "Your flying creature brings the baby " + species.ToString() + " down from the tree"), new RewardImpl.AnimalReward(animalReward), new List<string>() { TraitFactory.Traits.Flying.ToString() }));
        return e;
    }

    protected ExplorationEvent findACave(SpeciesFactory.Species species)
    {
        ExplorationEvent e = new ExplorationEvent();

        AnimalDef animalReward = AnimalDefFactory.CreateDefForSpecies(species);

        e.description = "You come across a cave, the opening looks treacherous. You think you hear an animal inside.";
        e.options = new List<ExplorationEvent.Option>();

        List<AnimalDef> twoAnimals = new List<AnimalDef>() { animalReward, animalReward };


        int strengthScore = animalReward.GetAttributeScore(TraitFactory.Attribute.Strength.ToString());

        List<ExplorationCriteria> variableAnimalReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, strengthScore, new RewardImpl.RandomAnimalPenalty("Somestimes things go into a cave, but don't come out.")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), strengthScore, strengthScore * 3, new RewardImpl.DoNothingReward("You can't clear the entrance.")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), strengthScore * 3, strengthScore * 6, new RewardImpl.AnimalReward (animalReward, "You find a baby " + species.ToString() + " in the cave.")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), strengthScore * 6, int.MaxValue, new RewardImpl.AnimalReward (twoAnimals))
        };

        e.options.Add(new ExplorationEvent.Option("Attempt to clear the entrance.", variableAnimalReward));

        int trackingScore = animalReward.GetAttributeScore(TraitFactory.Attribute.Tracking.ToString());

        List<ExplorationCriteria> variableTrackingReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, trackingScore, new RewardImpl.RandomAnimalPenalty()),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore, trackingScore * 3, new RewardImpl.DoNothingReward("You don't find another way in.")),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 3, trackingScore * 6, new RewardImpl.AnimalReward (animalReward)),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 6, int.MaxValue, new RewardImpl.AnimalReward (twoAnimals, "There were 2 of them in there.  You capture 2 baby " + species.ToString() + "."))
        };

        e.options.Add(new ExplorationEvent.Option("Attempt to find another way in.", variableTrackingReward));

        e.options.Add(new ExplorationEvent.Option("Walk away.", TraitFactory.Attribute.Tracking.ToString(), 0, new RewardImpl.DoNothingReward("You walk away."), new RewardImpl.DoNothingReward("You walk away.")));
        e.options.Add(
            new ExplorationEvent.Option("Send your climbing creature in.", TraitFactory.Attribute.Tracking.ToString(), trackingScore - 2, new RewardImpl.AnimalReward(animalReward, "Your climbing creature leads the way and finds a baby " + species.ToString() + "."),
                new RewardImpl.RandomAnimalPenalty("Even with a climbing creature to guide you, caves can still be hazzardous."), new List<string>() { TraitFactory.Traits.Climb.ToString() }));
        e.options.Add(
            new ExplorationEvent.Option("Dig through the rubble.", TraitFactory.Attribute.Strength.ToString(), strengthScore - 2, new RewardImpl.AnimalReward(animalReward, "You dig and dig until you find a baby " + species.ToString() + "."), new RewardImpl.DoNothingReward("You don't find anything."), new List<string>() { TraitFactory.Traits.Dig.ToString() }));
        return e;
    }
}

