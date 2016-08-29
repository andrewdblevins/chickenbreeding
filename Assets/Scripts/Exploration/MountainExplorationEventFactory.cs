using System.Collections.Generic;

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

        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Lion, 5));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Wolf, 5));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Bear, 5));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Bat, 12));

        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.BaldEagle));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Lion));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Bat));

        explorationEvents.Add(findACave(SpeciesFactory.Species.Bat));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Bear));
        explorationEvents.Add(findACave(SpeciesFactory.Species.BaldEagle));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Wolf));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Sheep));
        explorationEvents.Add(findACave(SpeciesFactory.Species.Lion));
    }
}