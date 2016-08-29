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
        explorationEvents.Add(animalStuckMud());
        explorationEvents.Add(fishRiver());
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

        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Alligator, 1));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Crocodile, 1));
        explorationEvents.Add(attackedBy(SpeciesFactory.Species.Hippo, 1));

        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Duck));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Penguin));
        explorationEvents.Add(babyInATree(SpeciesFactory.Species.Frog));
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
            new ExplorationEvent.Option("Because you have swim, you can reach the island and get the baby.", TraitFactory.Attribute.Fighting.ToString(), 0, new RewardImpl.AnimalReward(animalReward), new RewardImpl.AnimalReward(animalReward), new List<string>() { TraitFactory.Traits.Swim.ToString() }));
        e.options.Add(
            new ExplorationEvent.Option("Because you have flying, you can reach the island and get the baby.", TraitFactory.Attribute.Fighting.ToString(), 0, new RewardImpl.AnimalReward(animalReward), new RewardImpl.AnimalReward(animalReward), new List<string>() { TraitFactory.Traits.Flying.ToString() }));
        return e;
    }

    protected ExplorationEvent animalStuckMud()
    {
        ExplorationEvent e = new ExplorationEvent();

        e.description = "One of your animals gets stuck in deep mud. If you can't get it out, you'll have to leave it behind.";
        e.options = new List<ExplorationEvent.Option>();

        int strengthScore = 10;
        List<ExplorationCriteria> variableStuckReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), int.MinValue, strengthScore, new RewardImpl.RandomAnimalPenalty()),
            new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), strengthScore, int.MaxValue, new RewardImpl.DoNothingReward ("You get the animal free."))
        };

        e.options.Add(new ExplorationEvent.Option("Pull the animal out.", variableStuckReward));

        e.options.Add(
            new ExplorationEvent.Option("Dig the animal out.", TraitFactory.Attribute.Fighting.ToString(), 0, new RewardImpl.DoNothingReward("You get the animal free."), new RewardImpl.DoNothingReward("You get the animal free."), new List<string>() { TraitFactory.Traits.Dig.ToString() }));
        return e;
    }

    protected ExplorationEvent fishRiver()
    {
        ExplorationEvent e = new ExplorationEvent();

        e.description = "You see fish in the river.";
        e.options = new List<ExplorationEvent.Option>();

        int trackingScore = 6;
        List<ExplorationCriteria> variableFishReward = new List<ExplorationCriteria>() {
            new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), int.MinValue, trackingScore, new RewardImpl.RandomAnimalPenalty()),
            new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), trackingScore, trackingScore * 2, new RewardImpl.DoNothingReward("The fish gets away.")),
            new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), trackingScore * 2, trackingScore * 6, new RewardImpl.FoodReward(4)),
            new ExplorationCriteria (TraitFactory.Attribute.Strength.ToString (), trackingScore * 2, int.MaxValue,  new RewardImpl.FoodReward(12))
        };

        e.options.Add(new ExplorationEvent.Option("Walk away.", TraitFactory.Attribute.Tracking.ToString(), 0, new RewardImpl.DoNothingReward("You walk away."), new RewardImpl.DoNothingReward("You walk away.")));

        e.options.Add(new ExplorationEvent.Option("Try to catch the fish.", TraitFactory.Attribute.Tracking.ToString(), 20, new RewardImpl.FoodReward(8), new RewardImpl.FoodReward(4)));

        e.options.Add(
            new ExplorationEvent.Option("Send in your swimming animal.", TraitFactory.Attribute.Tracking.ToString(), 10, new RewardImpl.FoodReward(12), new RewardImpl.FoodReward(4), new List<string>() { TraitFactory.Traits.Swim.ToString() }));
        return e;
    }
}
