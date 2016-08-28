using System.Collections.Generic;
using UnityEngine;

abstract class BaseEventFactory
{
    public List<ExplorationEvent> explorationEvents = new List<ExplorationEvent>();

    public abstract void Init();

    public ExplorationEvent getEvent(WorldState ws)
    {
        if (explorationEvents.Count == 0)
        {
            Init();
        }
        for (int tries = 0; tries < 50; tries++)
        {
            int index = Random.Range(0, explorationEvents.Count);
            ExplorationEvent e = explorationEvents[index];
            if (e.precondition.check(ws)) return e;
        }

        Debug.Log("This is highly improbable");
        return null;
    }

    protected ExplorationEvent animalBabyFightMother(SpeciesFactory.Species species)
    {
        ExplorationEvent e = new ExplorationEvent();

        AnimalDef animalReward = new AnimalDef();
        switch (species)
        {
            case SpeciesFactory.Species.Cow:
                animalReward.SpeciesTrait = SpeciesFactory.createCow();
                animalReward.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Lion:
                animalReward.SpeciesTrait = SpeciesFactory.createLion();
                animalReward.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Turtle:
                animalReward.SpeciesTrait = SpeciesFactory.createTurtle();
                animalReward.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Turkey:
                animalReward.SpeciesTrait = SpeciesFactory.createTurkey();
                animalReward.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Lobster:
                animalReward.SpeciesTrait = SpeciesFactory.createLobster();
                animalReward.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Wolf:
                animalReward.SpeciesTrait = SpeciesFactory.createWolf();
                animalReward.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Bat:
                animalReward.SpeciesTrait = SpeciesFactory.createBat();
                animalReward.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Bison:
                animalReward.SpeciesTrait = SpeciesFactory.createBison();
                animalReward.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Bear:
                animalReward.SpeciesTrait = SpeciesFactory.createBear();
                animalReward.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Bee:
                animalReward.SpeciesTrait = SpeciesFactory.createBee();
                animalReward.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Crocodile:
                animalReward.SpeciesTrait = SpeciesFactory.createCrocodile();
                animalReward.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Bulldog:
                animalReward.SpeciesTrait = SpeciesFactory.createBulldog();
                animalReward.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Tiger:
                animalReward.SpeciesTrait = SpeciesFactory.createTiger();
                animalReward.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Deer:
                animalReward.SpeciesTrait = SpeciesFactory.createDeer();
                animalReward.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Bluejay:
                animalReward.SpeciesTrait = SpeciesFactory.createBluejay();
                animalReward.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Cat:
                animalReward.SpeciesTrait = SpeciesFactory.createCat();
                animalReward.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Alligator:
                animalReward.SpeciesTrait = SpeciesFactory.createAlligator();
                animalReward.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.BaldEagle:
                animalReward.SpeciesTrait = SpeciesFactory.createBaldEagle();
                animalReward.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Sheep:
                animalReward.SpeciesTrait = SpeciesFactory.createSheep();
                animalReward.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Panda:
                animalReward.SpeciesTrait = SpeciesFactory.createPanda();
                animalReward.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Fox:
                animalReward.SpeciesTrait = SpeciesFactory.createFox();
                animalReward.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Elephant:
                animalReward.SpeciesTrait = SpeciesFactory.createElephant();
                animalReward.SizeTrait = SizeFactory.createEnormous();
                break;
            case SpeciesFactory.Species.Dog:
                animalReward.SpeciesTrait = SpeciesFactory.createDog();
                animalReward.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Chicken:
                animalReward.SpeciesTrait = SpeciesFactory.createChicken();
                animalReward.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Gorilla:
                animalReward.SpeciesTrait = SpeciesFactory.createGorilla();
                animalReward.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Owl:
                animalReward.SpeciesTrait = SpeciesFactory.createOwl();
                animalReward.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Horse:
                animalReward.SpeciesTrait = SpeciesFactory.createHorse();
                animalReward.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Frog:
                animalReward.SpeciesTrait = SpeciesFactory.createFrog();
                animalReward.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Giraffe:
                animalReward.SpeciesTrait = SpeciesFactory.createGiraffe();
                animalReward.SizeTrait = SizeFactory.createEnormous();
                break;
            case SpeciesFactory.Species.Moose:
                animalReward.SpeciesTrait = SpeciesFactory.createMoose();
                animalReward.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Mouse:
                animalReward.SpeciesTrait = SpeciesFactory.createMouse();
                animalReward.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Canary:
                animalReward.SpeciesTrait = SpeciesFactory.createCanary();
                animalReward.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Pig:
                animalReward.SpeciesTrait = SpeciesFactory.createPig();
                animalReward.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Hippo:
                animalReward.SpeciesTrait = SpeciesFactory.createHippo();
                animalReward.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Donkey:
                animalReward.SpeciesTrait = SpeciesFactory.createDonkey();
                animalReward.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Monkey:
                animalReward.SpeciesTrait = SpeciesFactory.createMoneky();
                animalReward.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Duck:
                animalReward.SpeciesTrait = SpeciesFactory.createDuck();
                animalReward.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Snake:
                animalReward.SpeciesTrait = SpeciesFactory.createSnake();
                animalReward.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Penguin:
                animalReward.SpeciesTrait = SpeciesFactory.createPenguin();
                animalReward.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Rhino:
                animalReward.SpeciesTrait = SpeciesFactory.createRhino();
                animalReward.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Rabbit:
                animalReward.SpeciesTrait = SpeciesFactory.createRabbit();
                animalReward.SizeTrait = SizeFactory.createTiny();
                break;
            default:
                break;
        }

        e.description = "You come across a baby " + species.ToString() + ", its mother is nearby.";
        e.options = new List<ExplorationEvent.Option>() {
            new ExplorationEvent.Option("Grab it.  You are not afraid of a mama " + species.ToString() + ".", TraitFactory.Attribute.Fighting.ToString(),
            animalReward.GetAttributeScore(TraitFactory.Attribute.Fighting.ToString()), new List<AnimalDef>() { animalReward}, new List<string>()),
            new ExplorationEvent.Option("Walk away quietly.", TraitFactory.Attribute.Tracking.ToString(),
            animalReward.GetAttributeScore(TraitFactory.Attribute.Tracking.ToString()), new List<AnimalDef>(), new List<string>()),
        };

        return e;
    }
}

