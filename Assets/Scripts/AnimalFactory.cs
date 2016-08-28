using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalFactory : MonoBehaviour {

    public GameObject animalPrefab;

	public static AnimalFactory Instance;

	void Awake () {
		Instance = this;
	}

	public GameObject createAnimal(SpeciesTrait species, SizeTrait size) {
		GameObject pf = GameObject.Instantiate(animalPrefab);
		Animal animal = pf.GetComponent<Animal>();

		List<BaseTrait> allTraits = new List<BaseTrait> ();
		allTraits.Add (species);
		allTraits.Add (size);
		List<BaseTrait> miscTraits = TraitSelector.selectTraits (allTraits);
		animal.Initialize(species, size, miscTraits);

		return pf;
	}

    public GameObject createWolf()
    {
        return createAnimal(SpeciesFactory.createWolf(), SizeFactory.createMidsized());
    }

    public GameObject createRabbit()
    {
        return createAnimal(SpeciesFactory.createRabbit(), SizeFactory.createTiny());
    }

    public GameObject createChicken()
    {
		return createAnimal(SpeciesFactory.createChicken(), SizeFactory.createTiny());
    }

    public GameObject createCow()
    {
        return createAnimal(SpeciesFactory.createCow(), SizeFactory.createHuge());
    }

    public GameObject createLion()
    {
        return createAnimal(SpeciesFactory.createLion(), SizeFactory.createLarge());
    }

    public GameObject createTurtle()
    {
        return createAnimal(SpeciesFactory.createTurtle(), SizeFactory.createSmall());
    }

    public GameObject createTurkey()
    {
        return createAnimal(SpeciesFactory.createTurkey(), SizeFactory.createSmall());
    }

    public GameObject createLobster()
    {
        return createAnimal(SpeciesFactory.createLobster(), SizeFactory.createSmall());
    }

    public GameObject createBat()
    {
        return createAnimal(SpeciesFactory.createBat(), SizeFactory.createTiny());
    }

    public GameObject createBison()
    {
        return createAnimal(SpeciesFactory.createBison(), SizeFactory.createHuge());
    }

    public GameObject createBear()
    {
        return createAnimal(SpeciesFactory.createBear(), SizeFactory.createHuge());
    }

    public GameObject createBee()
    {
        return createAnimal(SpeciesFactory.createBee(), SizeFactory.createTiny());
    }

    public GameObject createCrocodile()
    {
        return createAnimal(SpeciesFactory.createCrocodile(), SizeFactory.createLarge());
    }

    public GameObject createBulldog()
    {
        return createAnimal(SpeciesFactory.createBulldog(), SizeFactory.createMidsized());
    }

    public GameObject createTiger()
    {
        return createAnimal(SpeciesFactory.createTiger(), SizeFactory.createLarge());
    }

    public GameObject createDeer()
    {
        return createAnimal(SpeciesFactory.createDeer(), SizeFactory.createMidsized());
    }

    public GameObject createBluejay()
    {
        return createAnimal(SpeciesFactory.createBluejay(), SizeFactory.createTiny());
    }

    public GameObject createCat()
    {
        return createAnimal(SpeciesFactory.createCat(), SizeFactory.createSmall());
    }

    public GameObject createAlligator()
    {
        return createAnimal(SpeciesFactory.createAlligator(), SizeFactory.createLarge());
    }

    public GameObject createBaldEagle()
    {
        return createAnimal(SpeciesFactory.createBaldEagle(), SizeFactory.createSmall());
    }

    public GameObject createSheep()
    {
        return createAnimal(SpeciesFactory.createSheep(), SizeFactory.createMidsized());
    }

    public GameObject createPanda()
    {
        return createAnimal(SpeciesFactory.createPanda(), SizeFactory.createLarge());
    }

    public GameObject createFox()
    {
        return createAnimal(SpeciesFactory.createFox(), SizeFactory.createMidsized());
    }

    public GameObject createElephant()
    {
        return createAnimal(SpeciesFactory.createElephant(), SizeFactory.createEnormous());
    }

    public GameObject createDog()
    {
        return createAnimal(SpeciesFactory.createDog(), SizeFactory.createMidsized());
    }

    public GameObject createGorilla()
    {
        return createAnimal(SpeciesFactory.createGorilla(), SizeFactory.createLarge());
    }

    public GameObject createOwl()
    {
        return createAnimal(SpeciesFactory.createOwl(), SizeFactory.createSmall());
    }

    public GameObject createHorse()
    {
        return createAnimal(SpeciesFactory.createHorse(), SizeFactory.createHuge());
    }

    public GameObject createFrog()
    {
        return createAnimal(SpeciesFactory.createFrog(), SizeFactory.createTiny());
    }

    public GameObject createGiraffe()
    {
        return createAnimal(SpeciesFactory.createGiraffe(), SizeFactory.createEnormous());
    }

    public GameObject createMoose()
    {
        return createAnimal(SpeciesFactory.createMoose(), SizeFactory.createHuge());
    }

    public GameObject createMouse()
    {
        return createAnimal(SpeciesFactory.createMouse(), SizeFactory.createTiny());
    }

    public GameObject createCanary()
    {
        return createAnimal(SpeciesFactory.createCanary(), SizeFactory.createTiny());
    }

    public GameObject createPig()
    {
        return createAnimal(SpeciesFactory.createPig(), SizeFactory.createMidsized());
    }

    public GameObject createHippo()
    {
        return createAnimal(SpeciesFactory.createHippo(), SizeFactory.createHuge());
    }

    public GameObject createDonkey()
    {
        return createAnimal(SpeciesFactory.createDonkey(), SizeFactory.createLarge());
    }

    public GameObject createMoneky()
    {
        return createAnimal(SpeciesFactory.createMoneky(), SizeFactory.createMidsized());
    }

    public GameObject createDuck()
    {
        return createAnimal(SpeciesFactory.createDuck(), SizeFactory.createSmall());
    }

    public GameObject createSnake()
    {
        return createAnimal(SpeciesFactory.createSnake(), SizeFactory.createSmall());
    }

    public GameObject createPenguin()
    {
        return createAnimal(SpeciesFactory.createPenguin(), SizeFactory.createMidsized());
    }

    public GameObject createRhino()
    {
        return createAnimal(SpeciesFactory.createRhino(), SizeFactory.createHuge());
    }

    public GameObject createFromDef(AnimalDef def)
    {
        GameObject animal = GameObject.Instantiate(animalPrefab);
        Animal animalScript = animal.GetComponent<Animal>();
        animalScript.Initialize(def.SpeciesTrait, def.SizeTrait);
        animalScript.Traits = def.Traits;
        return animal;
    }
}
