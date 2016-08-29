using System.Collections.Generic;

class GrasslandsExplorationEventFactory : BaseEventFactory
{
    protected static BaseEventFactory instance;

    private GrasslandsExplorationEventFactory()
    {

    }

    public static BaseEventFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new GrasslandsExplorationEventFactory();
        }
        return instance;
    }


    public override void Init()
    {
        explorationEvents = new List<ExplorationEvent>();
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Rabbit));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Donkey));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Mouse));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Horse));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Owl));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Chicken));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Sheep));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Cow));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Bison));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Bee));
    }
}
