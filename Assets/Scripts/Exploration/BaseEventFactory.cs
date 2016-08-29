using System.Collections.Generic;
using UnityEngine;

abstract class BaseEventFactory
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
        e.options.Add(
            new ExplorationEvent.Option("Grab it.  You are not afraid of a mama " + species.ToString() + ".", TraitFactory.Attribute.Fighting.ToString(),
            animalReward.GetAttributeScore(TraitFactory.Attribute.Fighting.ToString()), new List<AnimalDef>() { animalReward }, new List<string>()));
        e.options.Add(
            new ExplorationEvent.Option("Walk away quietly.", TraitFactory.Attribute.Tracking.ToString(),
            animalReward.GetAttributeScore(TraitFactory.Attribute.Tracking.ToString()), new List<AnimalDef>(), new List<string>()));
        if (trumpOption != null) {
            e.options.Add(
                new ExplorationEvent.Option("Because you have " + trumpOption + ", you can scare the mom away.", TraitFactory.Attribute.Fighting.ToString(), 0, new List<AnimalDef>() { animalReward }, new List<string>() { trumpOption }));
        }

        return e;
    }
}

