using UnityEngine;
using System.Collections.Generic;

public class ExplorationEventFactory
{
    public static ExplorationEvent createEvent()
    {
        ExplorationEvent e = new ExplorationEvent();

        e.description = "You encounter a wild Grue";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Fight the Grue", TraitFactory.Attribute.Fighting.ToString(), 7, new List<Animal>(), new List<BaseTrait>()),
            new ExplorationEvent.Option("Run like the wind", TraitFactory.Attribute.Tracking.ToString(), 2, new List<Animal>(), new List<BaseTrait>()),
            new ExplorationEvent.Option("Build a defensive wall", TraitFactory.Attribute.Strength.ToString(), 14, new List<Animal>(), new List<BaseTrait>())
        };

        return e;
    }
}
