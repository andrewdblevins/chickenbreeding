using System.Collections.Generic;

public class SpeciesFactory {
    static Dictionary<string, SpeciesTrait> instantiatedTraits = new Dictionary<string, SpeciesTrait>();

    /** This should only be referenced by data classes. */
    public enum Species
    {
		Cow, // 0 grasslands
        Lion, // 1 savana
        Turtle, // 2 riverlands
        Turkey, // 3 forest
        Lobster, // 4 riverlands
        Wolf, // 5 everywhere
        Bat, // 6 mountains
        Bison, // 8 grasslands
        Bear, // 9 forest, mountains
        Bee, // 11 forest, grass
		Crocodile, // 13 river
        Bulldog, // 14
        Tiger, // 15 jungle
        Deer,  // 17 forest
        Bluejay, // 18 forest
        Cat, // 19 forest
		Alligator, // 20 river
        BaldEagle, // 21 mountains
        Sheep, // 22 grass, mountains
        Panda, // 23 jungle
        Fox, // 24 forest
        Elephant, // 25 savanah, jungle
        Dog, // 26 
        Chicken, // 27 grasslands
        Gorilla, // 28 jungle
        Owl, // 29 forest, grasslands
        Horse, // 30 grasslands
        Frog, // 31 riverlands
        Giraffe, // 32 savanah
        Moose, // 33 forest
        Mouse, // 34 grasslands
        Canary, // 35 forest
        Pig, // 36 forest
        Hippo, // 37 river
        Donkey, // 38 grasslands
        Monkey, // 39 jungle
        Duck, // 40 riverlands
        Snake, // 41 jungle
        Penguin, // 42 riverlands
        Rhino, // 44 savanah
        Rabbit, // 45 grasslands

        //Ant, // 16
        //Ant, // 10
        //Fish, // 11
        //Shark, // 43
        //Butterfly, // 7
    }

    private static string SPECIES = "species";

    public static SpeciesTrait createWolf()
    {
        if (instantiatedTraits.ContainsKey(Species.Wolf.ToString()))
        {
            return instantiatedTraits[Species.Wolf.ToString()];
        }
        SpeciesTrait wolf = new SpeciesTrait();
        wolf.spriteIndex = 5;
        wolf.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        wolf.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 1);
        wolf.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        wolf.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        wolf.inheritanceChance = 1f;

        wolf.name = Species.Wolf.ToString();
        wolf.type = Species.Wolf.ToString();
        wolf.traitClass = SPECIES;

        wolf.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 3.0f);
        wolf.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 3.0f);

        instantiatedTraits[Species.Wolf.ToString()] = wolf;
        return wolf;
    }

    public static SpeciesTrait createRabbit()
    {
        if (instantiatedTraits.ContainsKey(Species.Rabbit.ToString()))
        {
            return instantiatedTraits[Species.Rabbit.ToString()];
        }
        SpeciesTrait rabbit = new SpeciesTrait();
        rabbit.spriteIndex = 45;
        rabbit.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), -1);
        rabbit.attributes.Add(TraitFactory.Attribute.Strength.ToString(), -1);
        rabbit.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        rabbit.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        rabbit.inheritanceChance = 1f;

        rabbit.name = Species.Rabbit.ToString();
        rabbit.type = Species.Rabbit.ToString();
        rabbit.traitClass = SPECIES;

        rabbit.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 3.0f);
        rabbit.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 6.0f);
        rabbit.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);

        instantiatedTraits[Species.Rabbit.ToString()] = rabbit;
        return rabbit;
    }

    public static SpeciesTrait createChicken()
    {
        string speciesString = Species.Chicken.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait chicken = new SpeciesTrait();
        chicken.spriteIndex = 27;
        chicken.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), -1);
        chicken.attributes.Add(TraitFactory.Attribute.Strength.ToString(), -1);
        chicken.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        chicken.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        chicken.inheritanceChance = 1f;

        chicken.name = speciesString;
        chicken.type = speciesString;
        chicken.traitClass = SPECIES;

        chicken.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 6.0f);
        chicken.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 3.0f);

        instantiatedTraits[speciesString] = chicken;
        return chicken;
    }

    public static SpeciesTrait createCow()
    {
        string speciesString = Species.Cow.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait cow = new SpeciesTrait();
        cow.spriteIndex = 0;
        cow.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        cow.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 3);
        cow.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        cow.attributes.Add(TraitFactory.Attribute.Food.ToString(), 5);

        cow.inheritanceChance = 1f;

        cow.name = speciesString;
        cow.type = speciesString;
        cow.traitClass = SPECIES;

		cow.linkageMap.Add(TraitFactory.Traits.Large.ToString(), 6.0f);
		cow.linkageMap.Add(TraitFactory.Traits.Horned.ToString(), 1.0f);
        cow.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);
        cow.linkageMap.Add(TraitFactory.Traits.Marbled.ToString(), 2.0f);
        cow.linkageMap.Add(TraitFactory.Traits.Fat.ToString(), 2.0f);

        instantiatedTraits[speciesString] = cow;
        return cow;
    }

    public static SpeciesTrait createLion()
    {
        string speciesString = Species.Lion.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait lion = new SpeciesTrait();
        lion.spriteIndex = 1;
        lion.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 4);
        lion.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 3);
        lion.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        lion.attributes.Add(TraitFactory.Attribute.Food.ToString(), 3);

        lion.inheritanceChance = 1f;

        lion.name = speciesString;
        lion.type = speciesString;
        lion.traitClass = SPECIES;

        lion.linkageMap.Add(TraitFactory.Traits.Large.ToString(), 6.0f);
		lion.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), 6.0f);
		lion.linkageMap.Add(TraitFactory.Traits.Stealthy.ToString(), 1.0f);
		lion.linkageMap.Add(TraitFactory.Traits.Aggressive.ToString(), 1.0f);


        instantiatedTraits[speciesString] = lion;
        return lion;
    }

    public static SpeciesTrait createTurtle()
    {
        string speciesString = Species.Turtle.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait turtle = new SpeciesTrait();
        turtle.spriteIndex = 2;
        turtle.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        turtle.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 1);
        turtle.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        turtle.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        turtle.inheritanceChance = 1f;

        turtle.name = speciesString;
        turtle.type = speciesString;
        turtle.traitClass = SPECIES;

        turtle.linkageMap.Add(TraitFactory.Traits.Small.ToString(), 6.0f);
		turtle.linkageMap.Add(TraitFactory.Traits.Armored.ToString(), 6.0f);
        turtle.linkageMap.Add(TraitFactory.Traits.Swim.ToString(), 4.0f);


        instantiatedTraits[speciesString] = turtle;
        return turtle;
    }

    public static SpeciesTrait createTurkey()
    {
        string speciesString = Species.Turkey.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait turkey = new SpeciesTrait();
        turkey.spriteIndex = 3;
        turkey.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        turkey.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 3);
        turkey.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        turkey.attributes.Add(TraitFactory.Attribute.Food.ToString(), 5);

        turkey.inheritanceChance = 1f;

        turkey.name = speciesString;
        turkey.type = speciesString;
        turkey.traitClass = SPECIES;

        turkey.linkageMap.Add(TraitFactory.Traits.Small.ToString(), 6.0f);
		turkey.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), 1.0f);
        turkey.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);

        instantiatedTraits[speciesString] = turkey;
        return turkey;
    }

    public static SpeciesTrait createLobster()
    {
        string speciesString = Species.Lobster.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait lobster = new SpeciesTrait();
        lobster.spriteIndex = 4;
        lobster.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 2);
        lobster.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 1);
        lobster.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        lobster.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        lobster.inheritanceChance = 1f;

        lobster.name = speciesString;
        lobster.type = speciesString;
        lobster.traitClass = SPECIES;

        lobster.linkageMap.Add(TraitFactory.Traits.Small.ToString(), 3.0f);
        lobster.linkageMap.Add(TraitFactory.Traits.Armored.ToString(), 3.0f);
		lobster.linkageMap.Add(TraitFactory.Traits.Spikes.ToString(), 1.0f);
        lobster.linkageMap.Add(TraitFactory.Traits.Swim.ToString(), 5.0f);
        lobster.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);


        instantiatedTraits[speciesString] = lobster;
        return lobster;
    }

    public static SpeciesTrait createBat()
    {
        string speciesString = Species.Bat.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait bat = new SpeciesTrait();
        bat.spriteIndex = 6;
        bat.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        bat.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 0);
        bat.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        bat.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        bat.inheritanceChance = 1f;

        bat.name = speciesString;
        bat.type = speciesString;
        bat.traitClass = SPECIES;

        bat.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 6.0f);
		bat.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), 6.0f);


        instantiatedTraits[speciesString] = bat;
        return bat;
    }

    public static SpeciesTrait createBison()
    {
        string speciesString = Species.Bison.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait bison = new SpeciesTrait();
        bison.spriteIndex = 8;
        bison.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        bison.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 5);
        bison.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        bison.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        bison.inheritanceChance = 1f;

        bison.name = speciesString;
        bison.type = speciesString;
        bison.traitClass = SPECIES;

        bison.linkageMap.Add(TraitFactory.Traits.Huge.ToString(), 6.0f);
        bison.linkageMap.Add(TraitFactory.Traits.Aggressive.ToString(), 2.0f);
        bison.linkageMap.Add(TraitFactory.Traits.Horned.ToString(), 7.0f);

        bison.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);
        bison.linkageMap.Add(TraitFactory.Traits.Fat.ToString(), 2.0f);
        bison.linkageMap.Add(TraitFactory.Traits.Marbled.ToString(), 2.0f);

        instantiatedTraits[speciesString] = bison;
        return bison;
    }

    public static SpeciesTrait createBear()
    {
        string speciesString = Species.Bear.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait bear = new SpeciesTrait();
        bear.spriteIndex = 9;
        bear.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 4);
        bear.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 4);
        bear.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        bear.attributes.Add(TraitFactory.Attribute.Food.ToString(), 3);

        bear.inheritanceChance = 1f;

        bear.name = speciesString;
        bear.type = speciesString;
        bear.traitClass = SPECIES;

        bear.linkageMap.Add(TraitFactory.Traits.Huge.ToString(), 6.0f);
        bear.linkageMap.Add(TraitFactory.Traits.Aggressive.ToString(), 6.0f);
        bear.linkageMap.Add(TraitFactory.Traits.Independent.ToString(), 3.0f);
		bear.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), 3.0f);

        bear.linkageMap.Add(TraitFactory.Traits.Fat.ToString(), 2.0f);

        instantiatedTraits[speciesString] = bear;
        return bear;
    }

    public static SpeciesTrait createBee()
    {
        string speciesString = Species.Bee.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait bee = new SpeciesTrait();
        bee.spriteIndex = 11;
        bee.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        bee.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 0);
        bee.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        bee.attributes.Add(TraitFactory.Attribute.Food.ToString(), 3);

        bee.inheritanceChance = 1f;

        bee.name = speciesString;
        bee.type = speciesString;
        bee.traitClass = SPECIES;

        bee.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 6.0f);
		bee.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), 6.0f);


        instantiatedTraits[speciesString] = bee;
        return bee;
    }

    public static SpeciesTrait createCrocodile()
    {
        string speciesString = Species.Crocodile.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait crocodile = new SpeciesTrait();
        crocodile.spriteIndex = 13;
        crocodile.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        crocodile.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 3);
        crocodile.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 1);
        crocodile.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        crocodile.inheritanceChance = 1f;

        crocodile.name = speciesString;
        crocodile.type = speciesString;
        crocodile.traitClass = SPECIES;

        crocodile.linkageMap.Add(TraitFactory.Traits.Large.ToString(), 6.0f);
		crocodile.linkageMap.Add(TraitFactory.Traits.Independent.ToString(), 6.0f);
		crocodile.linkageMap.Add(TraitFactory.Traits.Swim.ToString(), 6.0f);


        instantiatedTraits[speciesString] = crocodile;
        return crocodile;
    }

    public static SpeciesTrait createBulldog()
    {
        string speciesString = Species.Bulldog.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait bulldog = new SpeciesTrait();
        bulldog.spriteIndex = 14;
        bulldog.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        bulldog.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 2);
        bulldog.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 5);
        bulldog.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        bulldog.inheritanceChance = 1f;

        bulldog.name = speciesString;
        bulldog.type = speciesString;
        bulldog.traitClass = SPECIES;

        bulldog.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 6.0f);
		bulldog.linkageMap.Add(TraitFactory.Traits.Loyal.ToString(), 6.0f);
		bulldog.linkageMap.Add(TraitFactory.Traits.Aggressive.ToString(), 6.0f);


        instantiatedTraits[speciesString] = bulldog;
        return bulldog;
    }

    public static SpeciesTrait createTiger()
    {
        string speciesString = Species.Tiger.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait tiger = new SpeciesTrait();
        tiger.spriteIndex = 15;
        tiger.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 4);
        tiger.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 3);
        tiger.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 4);
        tiger.attributes.Add(TraitFactory.Attribute.Food.ToString(), 3);

        tiger.inheritanceChance = 1f;

        tiger.name = speciesString;
        tiger.type = speciesString;
        tiger.traitClass = SPECIES;

        tiger.linkageMap.Add(TraitFactory.Traits.Large.ToString(), 6.0f);
		tiger.linkageMap.Add(TraitFactory.Traits.Independent.ToString(), 1.0f);
		tiger.linkageMap.Add(TraitFactory.Traits.Aggressive.ToString(), 1.0f);
		tiger.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), 1.0f);




        instantiatedTraits[speciesString] = tiger;
        return tiger;
    }

    public static SpeciesTrait createDeer()
    {
        string speciesString = Species.Deer.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait deer = new SpeciesTrait();
        deer.spriteIndex = 17;
        deer.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        deer.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 2);
        deer.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        deer.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        deer.inheritanceChance = 1f;

        deer.name = speciesString;
        deer.type = speciesString;
        deer.traitClass = SPECIES;

        deer.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 6.0f);
		deer.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 1.0f);

        deer.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);


        instantiatedTraits[speciesString] = deer;
        return deer;
    }

    public static SpeciesTrait createBluejay()
    {
        string speciesString = Species.Bluejay.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait bluejay = new SpeciesTrait();
        bluejay.spriteIndex = 18;
        bluejay.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        bluejay.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 0);
        bluejay.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 3);
        bluejay.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        bluejay.inheritanceChance = 1f;

        bluejay.name = speciesString;
        bluejay.type = speciesString;
        bluejay.traitClass = SPECIES;

        bluejay.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 6.0f);
		bluejay.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), 6.0f);


        instantiatedTraits[speciesString] = bluejay;
        return bluejay;
    }

    public static SpeciesTrait createCat()
    {
        string speciesString = Species.Cat.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait cat = new SpeciesTrait();
        cat.spriteIndex = 19;
        cat.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        cat.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 2);
        cat.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 4);
        cat.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        cat.inheritanceChance = 1f;

        cat.name = speciesString;
        cat.type = speciesString;
        cat.traitClass = SPECIES;

        cat.linkageMap.Add(TraitFactory.Traits.Small.ToString(), 6.0f);
		cat.linkageMap.Add(TraitFactory.Traits.Independent.ToString(), 1.0f);
		cat.linkageMap.Add(TraitFactory.Traits.Climb.ToString(), 1.0f);
		cat.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 1.0f);




        instantiatedTraits[speciesString] = cat;
        return cat;
    }

    public static SpeciesTrait createAlligator()
    {
        string speciesString = Species.Alligator.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait alligator = new SpeciesTrait();
        alligator.spriteIndex = 20;
        alligator.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 4);
        alligator.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 3);
        alligator.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        alligator.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        alligator.inheritanceChance = 1f;

        alligator.name = speciesString;
        alligator.type = speciesString;
        alligator.traitClass = SPECIES;

        alligator.linkageMap.Add(TraitFactory.Traits.Large.ToString(), 6.0f);
		alligator.linkageMap.Add(TraitFactory.Traits.Swim.ToString(), 6.0f);


        instantiatedTraits[speciesString] = alligator;
        return alligator;
    }

    public static SpeciesTrait createBaldEagle()
    {
        string speciesString = Species.BaldEagle.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait baldEagle = new SpeciesTrait();
        baldEagle.spriteIndex = 21;
        baldEagle.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 2);
        baldEagle.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 1);
        baldEagle.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 6);
        baldEagle.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        baldEagle.inheritanceChance = 1f;

        baldEagle.name = speciesString;
        baldEagle.type = speciesString;
        baldEagle.traitClass = SPECIES;

        baldEagle.linkageMap.Add(TraitFactory.Traits.Small.ToString(), 6.0f);
        baldEagle.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), 8.0f);
        baldEagle.linkageMap.Add(TraitFactory.Traits.KeenEyes.ToString(), 6.0f);

        instantiatedTraits[speciesString] = baldEagle;
        return baldEagle;
    }

    public static SpeciesTrait createSheep()
    {
        string speciesString = Species.Sheep.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait sheep = new SpeciesTrait();
        sheep.spriteIndex = 22;
        sheep.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 0);
        sheep.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 2);
        sheep.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 1);
        sheep.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        sheep.inheritanceChance = 1f;

        sheep.name = speciesString;
        sheep.type = speciesString;
        sheep.traitClass = SPECIES;

        sheep.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 6.0f);
        sheep.linkageMap.Add(TraitFactory.Traits.Docile.ToString(), 6.0f);
		sheep.linkageMap.Add(TraitFactory.Traits.Spikes.ToString(), -6.0f);
        sheep.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);
        sheep.linkageMap.Add(TraitFactory.Traits.Fat.ToString(), 2.0f);
        sheep.linkageMap.Add(TraitFactory.Traits.Marbled.ToString(), 2.0f);

        instantiatedTraits[speciesString] = sheep;
        return sheep;
    }

    public static SpeciesTrait createPanda()
    {
        string speciesString = Species.Panda.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait panda = new SpeciesTrait();
        panda.spriteIndex = 23;
        panda.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 4);
        panda.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 4);
        panda.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 3);
        panda.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        panda.inheritanceChance = 1f;

        panda.name = speciesString;
        panda.type = speciesString;
        panda.traitClass = SPECIES;

        panda.linkageMap.Add(TraitFactory.Traits.Large.ToString(), 6.0f);
		panda.linkageMap.Add(TraitFactory.Traits.Slow.ToString(), 1.0f);


        instantiatedTraits[speciesString] = panda;
        return panda;
    }

    public static SpeciesTrait createFox()
    {
        string speciesString = Species.Fox.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait fox = new SpeciesTrait();
        fox.spriteIndex = 24;
        fox.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 2);
        fox.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 2);
        fox.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 5);
        fox.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        fox.inheritanceChance = 1f;

        fox.name = speciesString;
        fox.type = speciesString;
        fox.traitClass = SPECIES;

        fox.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 6.0f);
        fox.linkageMap.Add(TraitFactory.Traits.Independent.ToString(), 1.0f);
		fox.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 1.0f);


        instantiatedTraits[speciesString] = fox;
        return fox;
    }

    public static SpeciesTrait createElephant()
    {
        string speciesString = Species.Elephant.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait elephant = new SpeciesTrait();
        elephant.spriteIndex = 25;
        elephant.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 4);
        elephant.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 6);
        elephant.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        elephant.attributes.Add(TraitFactory.Attribute.Food.ToString(), 6);

        elephant.inheritanceChance = 1f;

        elephant.name = speciesString;
        elephant.type = speciesString;
        elephant.traitClass = SPECIES;

        elephant.linkageMap.Add(TraitFactory.Traits.Enormous.ToString(), 6.0f);
		elephant.linkageMap.Add(TraitFactory.Traits.Horned.ToString(), 6.0f);
	


        instantiatedTraits[speciesString] = elephant;
        return elephant;
    }

    public static SpeciesTrait createDog()
    {
        string speciesString = Species.Dog.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait dog = new SpeciesTrait();
        dog.spriteIndex = 26;
        dog.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        dog.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 2);
        dog.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 5);
        dog.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        dog.inheritanceChance = 1f;

        dog.name = speciesString;
        dog.type = speciesString;
        dog.traitClass = SPECIES;

        dog.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 6.0f);
		dog.linkageMap.Add(TraitFactory.Traits.Loyal.ToString(), 6.0f);


        instantiatedTraits[speciesString] = dog;
        return dog;
    }

    public static SpeciesTrait createGorilla()
    {
        string speciesString = Species.Gorilla.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait gorilla = new SpeciesTrait();
        gorilla.spriteIndex = 28;
        gorilla.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        gorilla.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 4);
        gorilla.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        gorilla.attributes.Add(TraitFactory.Attribute.Food.ToString(), 3);

        gorilla.inheritanceChance = 1f;

        gorilla.name = speciesString;
        gorilla.type = speciesString;
        gorilla.traitClass = SPECIES;

        gorilla.linkageMap.Add(TraitFactory.Traits.Large.ToString(), 6.0f);
		gorilla.linkageMap.Add(TraitFactory.Traits.Climb.ToString(), 6.0f);
		gorilla.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), 6.0f);


        instantiatedTraits[speciesString] = gorilla;
        return gorilla;
    }

    public static SpeciesTrait createOwl()
    {
        string speciesString = Species.Owl.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait owl = new SpeciesTrait();
        owl.spriteIndex = 29;
        owl.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 2);
        owl.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 1);
        owl.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 6);
        owl.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        owl.inheritanceChance = 1f;

        owl.name = speciesString;
        owl.type = speciesString;
        owl.traitClass = SPECIES;

        owl.linkageMap.Add(TraitFactory.Traits.Small.ToString(), 6.0f);
        owl.linkageMap.Add(TraitFactory.Traits.KeenEyes.ToString(), 6.0f);
        owl.linkageMap.Add(TraitFactory.Traits.KeenSmell.ToString(), 6.0f);
		owl.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), 6.0f);


        instantiatedTraits[speciesString] = owl;
        return owl;
    }

    public static SpeciesTrait createHorse()
    {
        string speciesString = Species.Horse.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait horse = new SpeciesTrait();
        horse.spriteIndex = 30;
        horse.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        horse.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 5);
        horse.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 1);
        horse.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        horse.inheritanceChance = 1f;

        horse.name = speciesString;
        horse.type = speciesString;
        horse.traitClass = SPECIES;

        horse.linkageMap.Add(TraitFactory.Traits.Huge.ToString(), 6.0f);
        horse.linkageMap.Add(TraitFactory.Traits.Docile.ToString(), 1.0f);
		horse.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 1.0f);

        instantiatedTraits[speciesString] = horse;
        return horse;
    }

    public static SpeciesTrait createFrog()
    {
        string speciesString = Species.Frog.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait frog = new SpeciesTrait();
        frog.spriteIndex = 31;
        frog.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        frog.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 0);
        frog.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        frog.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        frog.inheritanceChance = 1f;

        frog.name = speciesString;
        frog.type = speciesString;
        frog.traitClass = SPECIES;

        frog.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 6.0f);
		frog.linkageMap.Add(TraitFactory.Traits.Swim.ToString(), 4.0f);



        instantiatedTraits[speciesString] = frog;
        return frog;
    }

    public static SpeciesTrait createGiraffe()
    {
        string speciesString = Species.Giraffe.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait giraffe = new SpeciesTrait();
        giraffe.spriteIndex = 32;
        giraffe.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 2);
        giraffe.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 4);
        giraffe.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        giraffe.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        giraffe.inheritanceChance = 1f;

        giraffe.name = speciesString;
        giraffe.type = speciesString;
        giraffe.traitClass = SPECIES;

        giraffe.linkageMap.Add(TraitFactory.Traits.Enormous.ToString(), 6.0f);
		giraffe.linkageMap.Add(TraitFactory.Traits.Docile.ToString(), 3.0f);


        instantiatedTraits[speciesString] = giraffe;
        return giraffe;
    }

    public static SpeciesTrait createMoose()
    {
        string speciesString = Species.Moose.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait moose = new SpeciesTrait();
        moose.spriteIndex = 33;
        moose.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 4);
        moose.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 5);
        moose.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        moose.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        moose.inheritanceChance = 1f;

        moose.name = speciesString;
        moose.type = speciesString;
        moose.traitClass = SPECIES;

        moose.linkageMap.Add(TraitFactory.Traits.Huge.ToString(), 6.0f);
		moose.linkageMap.Add(TraitFactory.Traits.Aggressive.ToString(), 6.0f);
		moose.linkageMap.Add(TraitFactory.Traits.Horned.ToString(), 6.0f);

        moose.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);
        moose.linkageMap.Add(TraitFactory.Traits.Fat.ToString(), 2.0f);
        moose.linkageMap.Add(TraitFactory.Traits.Marbled.ToString(), 2.0f);

        instantiatedTraits[speciesString] = moose;
        return moose;
    }

    public static SpeciesTrait createMouse()
    {
        string speciesString = Species.Mouse.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait mouse = new SpeciesTrait();
        mouse.spriteIndex = 34;
        mouse.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        mouse.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 0);
        mouse.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        mouse.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        mouse.inheritanceChance = 1f;

        mouse.name = speciesString;
        mouse.type = speciesString;
        mouse.traitClass = SPECIES;

        mouse.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 6.0f);
        mouse.linkageMap.Add(TraitFactory.Traits.Docile.ToString(), 2.0f);
		mouse.linkageMap.Add(TraitFactory.Traits.Weak.ToString(), 2.0f);


        instantiatedTraits[speciesString] = mouse;
        return mouse;
    }

    public static SpeciesTrait createCanary()
    {
        string speciesString = Species.Canary.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait canary = new SpeciesTrait();
        canary.spriteIndex = 35;
        canary.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        canary.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 0);
        canary.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 4);
        canary.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        canary.inheritanceChance = 1f;

        canary.name = speciesString;
        canary.type = speciesString;
        canary.traitClass = SPECIES;

        canary.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 6.0f);
        canary.linkageMap.Add(TraitFactory.Traits.Docile.ToString(), 2.0f);
        canary.linkageMap.Add(TraitFactory.Traits.KeenEyes.ToString(), 6.0f);
		canary.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), 6.0f);


        instantiatedTraits[speciesString] = canary;
        return canary;
    }

    public static SpeciesTrait createPig()
    {
        string speciesString = Species.Pig.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait pig = new SpeciesTrait();
        pig.spriteIndex = 36;
        pig.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 2);
        pig.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 3);
        pig.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 3);
        pig.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        pig.inheritanceChance = 1f;

        pig.name = speciesString;
        pig.type = speciesString;
        pig.traitClass = SPECIES;

        pig.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 6.0f);
        pig.linkageMap.Add(TraitFactory.Traits.Docile.ToString(), 2.0f);
        pig.linkageMap.Add(TraitFactory.Traits.KeenSmell.ToString(), 2.0f);

        pig.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);
        pig.linkageMap.Add(TraitFactory.Traits.Fat.ToString(), 2.0f);
        pig.linkageMap.Add(TraitFactory.Traits.Marbled.ToString(), 2.0f);

        instantiatedTraits[speciesString] = pig;
        return pig;
    }

    public static SpeciesTrait createHippo()
    {
        string speciesString = Species.Hippo.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait hippo = new SpeciesTrait();
        hippo.spriteIndex = 37;
        hippo.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 4);
        hippo.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 5);
        hippo.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 1);
        hippo.attributes.Add(TraitFactory.Attribute.Food.ToString(), 5);

        hippo.inheritanceChance = 1f;

        hippo.name = speciesString;
        hippo.type = speciesString;
        hippo.traitClass = SPECIES;

        hippo.linkageMap.Add(TraitFactory.Traits.Huge.ToString(), 6.0f);
        hippo.linkageMap.Add(TraitFactory.Traits.Aggressive.ToString(), 3.0f);
        hippo.linkageMap.Add(TraitFactory.Traits.Independent.ToString(), 2.0f);
        hippo.linkageMap.Add(TraitFactory.Traits.Swim.ToString(), 6.0f);

        instantiatedTraits[speciesString] = hippo;
        return hippo;
    }

    public static SpeciesTrait createDonkey()
    {
        string speciesString = Species.Donkey.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait donkey = new SpeciesTrait();
        donkey.spriteIndex = 38;
        donkey.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        donkey.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 4);
        donkey.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 1);
        donkey.attributes.Add(TraitFactory.Attribute.Food.ToString(), 3);

        donkey.inheritanceChance = 1f;

        donkey.name = speciesString;
        donkey.type = speciesString;
        donkey.traitClass = SPECIES;

        donkey.linkageMap.Add(TraitFactory.Traits.Large.ToString(), 6.0f);

        instantiatedTraits[speciesString] = donkey;
        return donkey;
    }

    public static SpeciesTrait createMonkey()
    {
        string speciesString = Species.Monkey.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait monkey = new SpeciesTrait();
        monkey.spriteIndex = 39;
        monkey.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 2);
        monkey.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 3);
        monkey.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        monkey.attributes.Add(TraitFactory.Attribute.Food.ToString(), 3);

        monkey.inheritanceChance = 1f;

        monkey.name = speciesString;
        monkey.type = speciesString;
        monkey.traitClass = SPECIES;

        monkey.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 6.0f);
		monkey.linkageMap.Add(TraitFactory.Traits.Climb.ToString(), 6.0f);


        instantiatedTraits[speciesString] = monkey;
        return monkey;
    }

    public static SpeciesTrait createDuck()
    {
        string speciesString = Species.Duck.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait duck = new SpeciesTrait();
        duck.spriteIndex = 40;
        duck.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        duck.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 1);
        duck.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 1);
        duck.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        duck.inheritanceChance = 1f;

        duck.name = speciesString;
        duck.type = speciesString;
        duck.traitClass = SPECIES;

        duck.linkageMap.Add(TraitFactory.Traits.Small.ToString(), 6.0f);
        duck.linkageMap.Add(TraitFactory.Traits.Swim.ToString(), 5.0f);

        duck.linkageMap.Add(TraitFactory.Traits.Delicious.ToString(), 2.0f);

        instantiatedTraits[speciesString] = duck;
        return duck;
    }

    public static SpeciesTrait createSnake()
    {
        string speciesString = Species.Snake.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait snake = new SpeciesTrait();
        snake.spriteIndex = 41;
        snake.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        snake.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 2);
        snake.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 4);
        snake.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        snake.inheritanceChance = 1f;

        snake.name = speciesString;
        snake.type = speciesString;
        snake.traitClass = SPECIES;

        snake.linkageMap.Add(TraitFactory.Traits.Small.ToString(), 6.0f);
		snake.linkageMap.Add(TraitFactory.Traits.Independent.ToString(), 6.0f);


        instantiatedTraits[speciesString] = snake;
        return snake;
    }

    public static SpeciesTrait createPenguin()
    {
        string speciesString = Species.Penguin.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait penguin = new SpeciesTrait();
        penguin.spriteIndex = 42;
        penguin.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        penguin.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 1);
        penguin.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        penguin.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        penguin.inheritanceChance = 1f;

        penguin.name = speciesString;
        penguin.type = speciesString;
        penguin.traitClass = SPECIES;

        penguin.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 6.0f);
		penguin.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), -1.0f);
		penguin.linkageMap.Add(TraitFactory.Traits.Swim.ToString(), 3.0f);


        instantiatedTraits[speciesString] = penguin;
        return penguin;
    }

    public static SpeciesTrait createRhino()
    {
        string speciesString = Species.Rhino.ToString();
        if (instantiatedTraits.ContainsKey(speciesString))
        {
            return instantiatedTraits[speciesString];
        }
        SpeciesTrait rhino = new SpeciesTrait();
        rhino.spriteIndex = 44;
        rhino.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 5);
        rhino.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 5);
        rhino.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 1);
        rhino.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        rhino.inheritanceChance = 1f;

        rhino.name = speciesString;
        rhino.type = speciesString;
        rhino.traitClass = SPECIES;

        rhino.linkageMap.Add(TraitFactory.Traits.Huge.ToString(), 6.0f);
		rhino.linkageMap.Add(TraitFactory.Traits.Aggressive.ToString(), 6.0f);
		rhino.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), 6.0f);



        instantiatedTraits[speciesString] = rhino;
        return rhino;
    }
}
