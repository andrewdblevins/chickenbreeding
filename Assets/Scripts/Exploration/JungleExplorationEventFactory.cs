using System.Collections.Generic;

public class JungleExplorationEventFactory : BaseEventFactory
{
    protected static BaseEventFactory instance;

    private JungleExplorationEventFactory()
    {

    }

    public static BaseEventFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new JungleExplorationEventFactory();
        }
        return instance;
    }


    public override void Init()
    {
        explorationEvents = new List<ExplorationEvent>();
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Tiger));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Panda));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Elephant, SpeciesFactory.Species.Mouse.ToString()));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Gorilla));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Monkey));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Snake));

        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Tiger, 3));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Elephant, 2, SpeciesFactory.Species.Mouse.ToString()));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Gorilla, 3));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Snake, 2));
    }
}
