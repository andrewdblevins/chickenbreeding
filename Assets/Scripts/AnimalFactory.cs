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

    public GameObject createFromDef(AnimalDef def)
    {
        GameObject animal = GameObject.Instantiate(animalPrefab);
        Animal animalScript = animal.GetComponent<Animal>();
        animalScript.Initialize(def.SpeciesTrait, def.SizeTrait);
        animalScript.Traits = def.Traits;
        return animal;
    }
}
