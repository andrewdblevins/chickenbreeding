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
    }
}
