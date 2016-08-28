using UnityEngine;
using System.Collections.Generic;

public class ExplorationEventFactory
{
    public static ExplorationEvent createEvent()
    {
        ExplorationEvent e = new ExplorationEvent();
        AnimalDef wolfAnimal = new AnimalDef();
        wolfAnimal.SizeTrait = SizeFactory.createMidsized();
        wolfAnimal.SpeciesTrait = SpeciesFactory.createWolf();

        e.description = "A wild Grue has appeared";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Fight the Grue", TraitFactory.Attribute.Fighting.ToString(), 7, new List<AnimalDef>() { wolfAnimal}, new List<BaseTrait>()),
            new ExplorationEvent.Option("Run like the wind", TraitFactory.Attribute.Tracking.ToString(), 2, new List<AnimalDef>(), new List<BaseTrait>()),
            new ExplorationEvent.Option("Build a defensive wall", TraitFactory.Attribute.Strength.ToString(), 14, new List<AnimalDef>(), new List<BaseTrait>())
        };

        return e;
    }
}
