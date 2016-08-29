using System.Collections.Generic;

class AnimalDefFactory
{
    public static AnimalDef CreateDefForSpecies(SpeciesFactory.Species species)
    {
        return CreateDefForSpecies(species, true);
    }

    public static AnimalDef CreateDefForSpecies(SpeciesFactory.Species species, bool assignRandomTraits)
    {
        AnimalDef animalDef = new AnimalDef();
        switch (species)
        {
            case SpeciesFactory.Species.Cow:
                animalDef.SpeciesTrait = SpeciesFactory.createCow();
                animalDef.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Lion:
                animalDef.SpeciesTrait = SpeciesFactory.createLion();
                animalDef.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Turtle:
                animalDef.SpeciesTrait = SpeciesFactory.createTurtle();
                animalDef.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Turkey:
                animalDef.SpeciesTrait = SpeciesFactory.createTurkey();
                animalDef.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Lobster:
                animalDef.SpeciesTrait = SpeciesFactory.createLobster();
                animalDef.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Wolf:
                animalDef.SpeciesTrait = SpeciesFactory.createWolf();
                animalDef.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Bat:
                animalDef.SpeciesTrait = SpeciesFactory.createBat();
                animalDef.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Bison:
                animalDef.SpeciesTrait = SpeciesFactory.createBison();
                animalDef.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Bear:
                animalDef.SpeciesTrait = SpeciesFactory.createBear();
                animalDef.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Bee:
                animalDef.SpeciesTrait = SpeciesFactory.createBee();
                animalDef.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Crocodile:
                animalDef.SpeciesTrait = SpeciesFactory.createCrocodile();
                animalDef.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Bulldog:
                animalDef.SpeciesTrait = SpeciesFactory.createBulldog();
                animalDef.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Tiger:
                animalDef.SpeciesTrait = SpeciesFactory.createTiger();
                animalDef.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Deer:
                animalDef.SpeciesTrait = SpeciesFactory.createDeer();
                animalDef.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Bluejay:
                animalDef.SpeciesTrait = SpeciesFactory.createBluejay();
                animalDef.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Cat:
                animalDef.SpeciesTrait = SpeciesFactory.createCat();
                animalDef.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Alligator:
                animalDef.SpeciesTrait = SpeciesFactory.createAlligator();
                animalDef.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.BaldEagle:
                animalDef.SpeciesTrait = SpeciesFactory.createBaldEagle();
                animalDef.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Sheep:
                animalDef.SpeciesTrait = SpeciesFactory.createSheep();
                animalDef.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Panda:
                animalDef.SpeciesTrait = SpeciesFactory.createPanda();
                animalDef.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Fox:
                animalDef.SpeciesTrait = SpeciesFactory.createFox();
                animalDef.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Elephant:
                animalDef.SpeciesTrait = SpeciesFactory.createElephant();
                animalDef.SizeTrait = SizeFactory.createEnormous();
                break;
            case SpeciesFactory.Species.Dog:
                animalDef.SpeciesTrait = SpeciesFactory.createDog();
                animalDef.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Chicken:
                animalDef.SpeciesTrait = SpeciesFactory.createChicken();
                animalDef.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Gorilla:
                animalDef.SpeciesTrait = SpeciesFactory.createGorilla();
                animalDef.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Owl:
                animalDef.SpeciesTrait = SpeciesFactory.createOwl();
                animalDef.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Horse:
                animalDef.SpeciesTrait = SpeciesFactory.createHorse();
                animalDef.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Frog:
                animalDef.SpeciesTrait = SpeciesFactory.createFrog();
                animalDef.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Giraffe:
                animalDef.SpeciesTrait = SpeciesFactory.createGiraffe();
                animalDef.SizeTrait = SizeFactory.createEnormous();
                break;
            case SpeciesFactory.Species.Moose:
                animalDef.SpeciesTrait = SpeciesFactory.createMoose();
                animalDef.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Mouse:
                animalDef.SpeciesTrait = SpeciesFactory.createMouse();
                animalDef.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Canary:
                animalDef.SpeciesTrait = SpeciesFactory.createCanary();
                animalDef.SizeTrait = SizeFactory.createTiny();
                break;
            case SpeciesFactory.Species.Pig:
                animalDef.SpeciesTrait = SpeciesFactory.createPig();
                animalDef.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Hippo:
                animalDef.SpeciesTrait = SpeciesFactory.createHippo();
                animalDef.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Donkey:
                animalDef.SpeciesTrait = SpeciesFactory.createDonkey();
                animalDef.SizeTrait = SizeFactory.createLarge();
                break;
            case SpeciesFactory.Species.Monkey:
                animalDef.SpeciesTrait = SpeciesFactory.createMonkey();
                animalDef.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Duck:
                animalDef.SpeciesTrait = SpeciesFactory.createDuck();
                animalDef.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Snake:
                animalDef.SpeciesTrait = SpeciesFactory.createSnake();
                animalDef.SizeTrait = SizeFactory.createSmall();
                break;
            case SpeciesFactory.Species.Penguin:
                animalDef.SpeciesTrait = SpeciesFactory.createPenguin();
                animalDef.SizeTrait = SizeFactory.createMidsized();
                break;
            case SpeciesFactory.Species.Rhino:
                animalDef.SpeciesTrait = SpeciesFactory.createRhino();
                animalDef.SizeTrait = SizeFactory.createHuge();
                break;
            case SpeciesFactory.Species.Rabbit:
                animalDef.SpeciesTrait = SpeciesFactory.createRabbit();
                animalDef.SizeTrait = SizeFactory.createTiny();
                break;
            default:
                break;
        }

        List<BaseTrait> allTraits = new List<BaseTrait>();
        allTraits.Add(animalDef.SpeciesTrait);
        allTraits.Add(animalDef.SizeTrait);
        animalDef.Traits = TraitSelector.selectTraits(allTraits);
        return animalDef;
    }
}
