using System.Collections.Generic;

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
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Turkey));
		explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Wolf));
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

	}
}
