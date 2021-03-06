﻿using System.Collections.Generic;

class GrasslandsExplorationEventFactory : BaseEventFactory
{
    protected static BaseEventFactory instance;

    private GrasslandsExplorationEventFactory()
    {

    }

    public static BaseEventFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new GrasslandsExplorationEventFactory();
        }
        return instance;
    }


    public override void Init()
    {
        explorationEvents = new List<ExplorationEvent>();
        explorationEvents.Add(stealEggs());
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Rabbit));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Donkey));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Mouse));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Horse));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Owl));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Chicken));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Sheep));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Cow));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Bison));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Bee));

		explorationEvents.Add(rescueFromQuicksand(SpeciesFactory.Species.Rabbit));
		explorationEvents.Add(rescueFromQuicksand(SpeciesFactory.Species.Rabbit, 3));

        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Bee, 12));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Wolf, 2));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Bison, 2));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Cow, 2));

        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Owl));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Chicken));

        explorationEvents.Add(findACave(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Mouse));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Rabbit));

    }

    public static ExplorationEvent stealEggs()
    {
        ExplorationEvent e = new ExplorationEvent();

        AnimalDef chicken = new AnimalDef();
        chicken.SizeTrait = SizeFactory.createTiny();
        chicken.SpeciesTrait = SpeciesFactory.createChicken();

        List<AnimalDef> twoChickens = new List<AnimalDef>() { chicken, chicken };

        List<ExplorationCriteria> variableChickenReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), int.MinValue, 6, new RewardImpl.RandomAnimalPenalty()),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), 6, 10, new RewardImpl.DoNothingReward("The Chicken looks kinda scary, and you back off.")),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), 10, 20, new RewardImpl.AnimalReward (chicken, "You defeat the mother and get one unbroken egg from the nest.")),
            new ExplorationCriteria (TraitFactory.Attribute.Fighting.ToString (), 20, int.MaxValue, new RewardImpl.AnimalReward (twoChickens, "After defeating the mother there are two viable eggs left in the nest."))
        };

        e.description = "You see a nest with a few eggs.  Its mother, a hugely oversized chicken, is nearby.";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Fight the chicken", variableChickenReward),
            new ExplorationEvent.Option("Run like the wind", TraitFactory.Attribute.Tracking.ToString(), 4, new RewardImpl.DoNothingReward("You run away"), new RewardImpl.RandomAnimalPenalty(), new List<string>()),
            new ExplorationEvent.Option("Build a defensive wall", TraitFactory.Attribute.Strength.ToString(), 20, new RewardImpl.DoNothingReward("You build a wall and make the chicken pay for it."), new RewardImpl.RandomAnimalPenalty(), new List<string>())
        };

        return e;
    }
}
