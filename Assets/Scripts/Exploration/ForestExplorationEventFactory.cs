﻿using System.Collections.Generic;

class ForestExplorationEventFactory : BaseEventFactory
{
	protected static BaseEventFactory instance;

	private ForestExplorationEventFactory()
	{

	}

	public static BaseEventFactory GetInstance()
	{
		if (instance == null)
		{
			instance = new ForestExplorationEventFactory();
		}
		return instance;
	}

	public override void Init()
	{
		explorationEvents = new List<ExplorationEvent>();
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Deer));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Bear));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Bee));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Deer));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Bluejay));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Cat));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.BaldEagle));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Fox));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Owl));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Moose));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Canary));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Pig));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Rabbit));

		explorationEvents.Add(rescueFromQuicksand(SpeciesFactory.Species.Pig));
		explorationEvents.Add(rescueFromQuicksand(SpeciesFactory.Species.Rabbit));
		explorationEvents.Add(rescueFromQuicksand(SpeciesFactory.Species.Cat, 2));
		explorationEvents.Add(rescueFromQuicksand(SpeciesFactory.Species.Deer));
		explorationEvents.Add(rescueFromQuicksand(SpeciesFactory.Species.Pig, 2));
		explorationEvents.Add(rescueFromQuicksand(SpeciesFactory.Species.Rabbit, 2));
		explorationEvents.Add(rescueFromQuicksand(SpeciesFactory.Species.Cat, 3));


        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Bear, 2));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Cat, 2));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Fox, 2));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Moose, 2));

        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Bluejay));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Cat));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Fox));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Owl));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Canary));

        explorationEvents.Add(findACave(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Bear));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Deer));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Cat));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Fox));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Pig));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Rabbit));
    }
}
