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
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Alligator));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Frog));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Lobster));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Turtle));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Crocodile));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Hippo));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Duck));
        explorationEvents.Add(animalBabyFightMother(SpeciesFactory.Species.Penguin));

        explorationEvents.Add(babyIslandSwim(SpeciesFactory.Species.Frog));
        explorationEvents.Add(babyIslandSwim(SpeciesFactory.Species.Lobster));
        explorationEvents.Add(babyIslandSwim(SpeciesFactory.Species.Turtle));
        explorationEvents.Add(babyIslandSwim(SpeciesFactory.Species.Penguin));
        explorationEvents.Add(babyIslandSwim(SpeciesFactory.Species.Duck));
    }

    protected ExplorationEvent babyIslandSwim(SpeciesFactory.Species species)
    {
        ExplorationEvent e = new ExplorationEvent();

        AnimalDef animalReward = AnimalDefFactory.CreateDefForSpecies(species);

        e.description = "You come across a baby " + species.ToString() + " on an island.";
        e.options = new List<ExplorationEvent.Option>();

        List<AnimalDef> twoAnimals = new List<AnimalDef>() { animalReward, animalReward };

        int strengthScore = animalReward.GetAttributeScore(TraitFactory.Attribute.Strength.ToString());

        List<ExplorationCriteria> variableAnimalReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), int.MinValue, strengthScore, new RewardImpl.RandomAnimalPenalty()),
            new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), strengthScore, strengthScore * 2, new RewardImpl.DoNothingReward("The tree doesn't budge.")),
            new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), strengthScore * 2 , int.MaxValue, new RewardImpl.AnimalReward (animalReward))
        };

        e.options.Add(new ExplorationEvent.Option("There is a tree nearby, you can try to push it over.", variableAnimalReward));
        e.options.Add(new ExplorationEvent.Option("Walk away.", TraitFactory.Attribute.Tracking.ToString(), 0, new RewardImpl.DoNothingReward("You walk away."), new RewardImpl.DoNothingReward("You walk away.")));

        e.options.Add(
            new ExplorationEvent.Option("Because you have swim, you can reach the island and get the baby.", TraitFactory.Attribute.Fighting.ToString(), 0, new List<AnimalDef>() { animalReward }, new List<string>() { TraitFactory.Traits.Swim.ToString() }));
        e.options.Add(
            new ExplorationEvent.Option("Because you have flying, you can reach the island and get the baby.", TraitFactory.Attribute.Fighting.ToString(), 0, new List<AnimalDef>() { animalReward }, new List<string>() { TraitFactory.Traits.Flying.ToString() }));
        return e;
    }
}
