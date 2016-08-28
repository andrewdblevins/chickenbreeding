using UnityEngine;
using System.Collections.Generic;

public class ExplorationEventFactory
{
    public static List<ExplorationEvent> explorationEvents;

    public static void init()
    {
        explorationEvents = new List<ExplorationEvent>(20);
        explorationEvents.Add(createEvent());
        explorationEvents.Add(wolfAttack());
        explorationEvents.Add(riverCrossing());
        explorationEvents.Add(lost());
        explorationEvents.Add(bearCub());
        explorationEvents.Add(keenEyes());
        explorationEvents.Add(captureChicken());
    }


    public static ExplorationEvent getEvent(WorldState ws)
    {
        if (explorationEvents.Count == 0) return createEvent();

        for (int tries = 0; tries < 50; tries++)
        {
            int index = Random.Range(0, explorationEvents.Count);
            ExplorationEvent e = explorationEvents[index];
            if (e.precondition.check(ws)) return e;
        }

        Debug.Log("This is highly improbable");
        return createEvent();
    }

    public static ExplorationEvent createEvent()
    {
        ExplorationEvent e = new ExplorationEvent();
        AnimalDef wolfAnimal = new AnimalDef();
        wolfAnimal.SizeTrait = SizeFactory.createMidsized();
        wolfAnimal.SpeciesTrait = SpeciesFactory.createWolf();

        e.description = "A wild Grue has appeared";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Fight the Grue", TraitFactory.Attribute.Fighting.ToString(), 7, new List<AnimalDef>() { wolfAnimal}, new List<string>()),
            new ExplorationEvent.Option("Run like the wind", TraitFactory.Attribute.Tracking.ToString(), 2, new List<AnimalDef>(), new List<string>()),
            new ExplorationEvent.Option("Build a defensive wall", TraitFactory.Attribute.Strength.ToString(), 14, new List<AnimalDef>(), new List<string>())
        };

        return e;
    }

    public static ExplorationEvent wolfAttack()
    {
        ExplorationEvent e = new ExplorationEvent();

        e.description = "You are attacked by a pack of wild wolves";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Stand and fight", TraitFactory.Attribute.Fighting.ToString(), 7, new List<AnimalDef>(), new List<string>()),
            new ExplorationEvent.Option("Run like the wind", TraitFactory.Attribute.Tracking.ToString(), 6, new List<AnimalDef>(), new List<string>()),
            new ExplorationEvent.Option("Negotiate.  You are the Alpha.", TraitFactory.Attribute.Fighting.ToString(), 3, new List<AnimalDef>(), new List<string>() { SpeciesFactory.Species.Wolf.ToString()})
        };

        return e;
    }

    public static ExplorationEvent riverCrossing()
    {
        ExplorationEvent e = new ExplorationEvent();

        e.description = "You need to cross a river";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Lets go", TraitFactory.Attribute.Strength.ToString(), 7, new List<AnimalDef>(), new List<string>()),
            new ExplorationEvent.Option("Find a better place to cross", TraitFactory.Attribute.Tracking.ToString(), 6, new List<AnimalDef>(), new List<string>()),
        };

        return e;
    }

    public static ExplorationEvent lost()
    {
        ExplorationEvent e = new ExplorationEvent();

        e.description = "You seem to be lost";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Find the trail", TraitFactory.Attribute.Tracking.ToString(), 7, new List<AnimalDef>(), new List<string>()),
            new ExplorationEvent.Option("Send out a flying scout", TraitFactory.Attribute.Tracking.ToString(), 7, new List<AnimalDef>(), new List<string>() {TraitFactory.Traits.Flying.ToString() }),
            new ExplorationEvent.Option("I dont need a trail, follow the setting sun.", TraitFactory.Attribute.Strength.ToString(), 9, new List<AnimalDef>(), new List<string>()),
        };

        return e;
    }

    public static ExplorationEvent bearCub()
    {
        ExplorationEvent e = new ExplorationEvent();

        AnimalDef wolfAnimal = new AnimalDef();
        wolfAnimal.SizeTrait = SizeFactory.createMidsized();
        wolfAnimal.SpeciesTrait = SpeciesFactory.createWolf();

        e.description = "You come across a bear cub, its mother is nearby.";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Grab it.  You are not afraid of a mama grizzly.", TraitFactory.Attribute.Fighting.ToString(), 9, new List<AnimalDef>() { wolfAnimal}, new List<string>()),
            new ExplorationEvent.Option("Walk away quietly.", TraitFactory.Attribute.Tracking.ToString(), 3, new List<AnimalDef>(), new List<string>()),
        };

        return e;
    }

    public static ExplorationEvent keenEyes()
    {
        ExplorationEvent e = new ExplorationEvent();

        e.precondition = new EventCondition(EventCondition.numKeenEyes, EventCondition.atLeast, 1);

        AnimalDef rabbitAnimal = new AnimalDef();
        rabbitAnimal.SizeTrait = SizeFactory.createTiny();
        rabbitAnimal.SpeciesTrait = SpeciesFactory.createRabbit();

        e.description = "You see a rabbit hiding in the bushes";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Kill it", TraitFactory.Attribute.Fighting.ToString(), 2, new List<AnimalDef>() { rabbitAnimal}, new List<string>()),
            new ExplorationEvent.Option("Catch it", TraitFactory.Attribute.Tracking.ToString(), 6, new List<AnimalDef>() { rabbitAnimal}, new List<string>()),
        };

        return e;
    }

    public static ExplorationEvent captureChicken()
    {
        ExplorationEvent e = new ExplorationEvent();

        e.precondition = new EventCondition(EventCondition.numKeenEyes, EventCondition.atLeast, 1);

        AnimalDef chicken = new AnimalDef();
        chicken.SizeTrait = SizeFactory.createTiny();
        chicken.SpeciesTrait = SpeciesFactory.createChicken();

        e.description = "You see a chicken hiding in the bushes";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("sneek up on it", TraitFactory.Attribute.Tracking.ToString(), 2, new List<AnimalDef>() { chicken}, new List<string>())
        };

        return e;
    }
}
