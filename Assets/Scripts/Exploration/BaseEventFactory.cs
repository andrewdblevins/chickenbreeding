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
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), int.MinValue, fightScore * 2, new RewardImpl.RandomAnimalPenalty()),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 2, fightScore * 2 + 1, new RewardImpl.DoNothingReward("The " + species.ToString() + " looks kinda scary, and you back off.")),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 2 + 1, fightScore * 4, new RewardImpl.AnimalReward (animalReward)),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 4, int.MaxValue, new RewardImpl.AnimalReward (twoAnimals))
        };

        List<ExplorationCriteria> variableTrackingReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, trackingScore, new RewardImpl.RandomAnimalPenalty()),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore, trackingScore * 2, new RewardImpl.FoodPenalty(animalReward.GetAttributeScore(TraitFactory.Attribute.Food.ToString()))),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), trackingScore * 2, trackingScore * 4, new RewardImpl.FoodReward(animalReward.GetAttributeScore(TraitFactory.Attribute.Food.ToString()))),
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString(), trackingScore * 4, int.MaxValue, new RewardImpl.AnimalReward (animalReward))
        };


        e.options.Add(new ExplorationEvent.Option("Grab it.  You are not afraid of a mama " + species.ToString() + ".", variableAnimalReward));
        e.options.Add(new ExplorationEvent.Option("Walk away quietly.", variableTrackingReward));

        if (trumpOption != null) {
            e.options.Add(
                new ExplorationEvent.Option("Because you have " + trumpOption + ", you can scare the mom away.", TraitFactory.Attribute.Fighting.ToString(), 0, new RewardImpl.AnimalReward(animalReward), new RewardImpl.DoNothingReward("Nothing interesting happens."), new List<string>() { trumpOption }));
        }

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
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), int.MinValue, fightScore * 2, new RewardImpl.RandomAnimalPenalty()),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 2, fightScore * 2 + 3, new RewardImpl.FoodPenalty(25,
                "The " + species.ToString() + " nearly killed you.  Before you dealt the winning blow it tore into your pack and scatterd your suppplies.  You lost 25 food.")),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), fightScore * 2 + 3, int.MaxValue, new RewardImpl.FoodReward(foodReward, foodString))
        };

        List<ExplorationCriteria> variableTrackingReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Tracking.ToString (), int.MinValue, trackingScore, new RewardImpl.RandomAnimalPenalty()),
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
}

