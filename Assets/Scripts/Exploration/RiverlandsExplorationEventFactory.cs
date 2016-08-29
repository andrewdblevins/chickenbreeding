using System.Collections.Generic;

class RiverlandsExplorationEventFactory : BaseEventFactory
{
    protected static BaseEventFactory instance;

    private RiverlandsExplorationEventFactory()
    {
        
    }

    public static BaseEventFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new RiverlandsExplorationEventFactory();
        }
        return instance;
    }
    

    public override void Init()
    {
        explorationEvents = new List<ExplorationEvent>();
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Alligator, SpeciesFactory.Species.Chicken.ToString()));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Frog));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Lobster));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Turtle));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Crocodile));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Hippo));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Duck));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Penguin));
		explorationEvents.Add(stealEggs());
    }


	public static ExplorationEvent stealEggs()
	{
		ExplorationEvent e = new ExplorationEvent();

		AnimalDef chicken = new AnimalDef();
		chicken.SizeTrait = SizeFactory.createTiny();
		chicken.SpeciesTrait = SpeciesFactory.createChicken();

		List<AnimalDef> twoChickens = new List<AnimalDef>() { chicken, chicken };

		List<ExplorationCriteria> variableChickenReward = new List<ExplorationCriteria> () {
			new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), int.MinValue, 4, new RewardImpl.RandomAnimalPenalty()),
			new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), 4, 7, new RewardImpl.DoNothingReward("The Chicken looks kinda scary, and you back off.")),
			new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), 7, 10, new RewardImpl.AnimalReward (chicken)),
			new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), 10, int.MaxValue, new RewardImpl.AnimalReward (twoChickens))
		};

		e.description = "You see a nest with a few eggs.  Its mother, a hugely oversized chicken, is nearby.";
		e.options = new List<ExplorationEvent.Option>() {
			new ExplorationEvent.Option("Fight the chicken", variableChickenReward),
			new ExplorationEvent.Option("Run like the wind", TraitFactory.Attribute.Tracking.ToString(), 2, new List<AnimalDef>(), new List<string>()),
			new ExplorationEvent.Option("Build a defensive wall", TraitFactory.Attribute.Strength.ToString(), 14, new List<AnimalDef>(), new List<string>())
		};

		return e;
	}
}
