﻿using System.Collections.Generic;

public class MountainExplorationEventFactory : BaseEventFactory
{
    protected static BaseEventFactory instance;

    private MountainExplorationEventFactory()
    {

    }

    public static BaseEventFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new MountainExplorationEventFactory();
        }
        return instance;
    }

    public override void Init()
    {
        explorationEvents = new List<ExplorationEvent>();
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Bat));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Bear));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.BaldEagle));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Sheep));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Lion));
    }
}