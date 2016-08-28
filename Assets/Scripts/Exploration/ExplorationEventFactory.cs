using UnityEngine;
using System.Collections.Generic;

public class ExplorationEventFactory
{
    public static List<ExplorationEvent> explorationEvents;

    public static void init()
    {
        explorationEvents = new List<ExplorationEvent>(20);
        //explorationEvents.Add()
    }





    public static ExplorationEvent createEvent()
    {
        ExplorationEvent e = new ExplorationEvent();

        GameObject obj = new GameObject();
        Animal wolfAnimal = obj.AddComponent<Animal>();
        wolfAnimal.Initialize(SpeciesFactory.createWolf(), SizeFactory.createMidsized());

        e.description = "A wild Grue has appeared";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Fight the Grue", TraitFactory.Attribute.Fighting.ToString(), 7, new List<Animal>() { wolfAnimal}, new List<BaseTrait>()),
            new ExplorationEvent.Option("Run like the wind", TraitFactory.Attribute.Tracking.ToString(), 2, new List<Animal>(), new List<BaseTrait>()),
            new ExplorationEvent.Option("Build a defensive wall", TraitFactory.Attribute.Strength.ToString(), 14, new List<Animal>(), new List<BaseTrait>())
        };

        return e;
    }
}
