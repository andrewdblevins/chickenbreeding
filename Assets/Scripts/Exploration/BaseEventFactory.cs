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
}

