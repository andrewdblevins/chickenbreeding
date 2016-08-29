﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SavanaExplorationEventFactory : BaseEventFactory
{
    protected static BaseEventFactory instance;

    private SavanaExplorationEventFactory()
    {

    }

    public static BaseEventFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new SavanaExplorationEventFactory();
        }
        return instance;
    }

    public override void Init()
    {
        explorationEvents = new List<ExplorationEvent>();
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Lion));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Elephant));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Giraffe));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Rhino));

    }
}