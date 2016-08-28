using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    private AnimalDef def = new AnimalDef();
    public Sprite[] animals;
    public GameObject animalPrefab;

    public SpeciesTrait SpeciesTrait
    {
        get
        {
            return def.SpeciesTrait;
        }

        set
        {
            def.SpeciesTrait = value;
        }
    }

    public SizeTrait SizeTrait
    {
        get
        {
            return def.SizeTrait;
        }

        set
        {
            def.SizeTrait = value;
        }
    }

    public List<BaseTrait> Traits
    {
        get
        {
            return def.Traits;
        }

        set
        {
            def.Traits = value;
        }
    }

	public void Initialize(SpeciesTrait species, SizeTrait size) {
		Initialize (species, size, new List<BaseTrait> ());
	}

	public void Initialize(SpeciesTrait species, SizeTrait size, List<BaseTrait> inputTraits)
	{
		SpeciesTrait = species;
		SizeTrait = size;
		Traits = inputTraits;

        Image image = GetComponent<Image>();
        if (image != null)
        {
            image.sprite = animals[species.spriteIndex];
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddTrait(BaseTrait trait)
    {
        Traits.Add(trait);
    }

    public bool CanBreedWith(Animal mate)
    {
        return SpeciesTrait.isCompatible(mate.SpeciesTrait) && SizeTrait.isCompatible(mate.SizeTrait);
    }

    public GameObject breedWith (Animal mate)
    {
        if (!CanBreedWith(mate))
        {
            return null;
        }

        GameObject baby = GameObject.Instantiate(animalPrefab);
        Animal babyAnimal = baby.GetComponent<Animal>();

        List<BaseTrait> mandatoryTraits = new List<BaseTrait>();
        SizeTrait babySize = TraitSelector.selectSize(SpeciesTrait, SizeTrait, mate.SizeTrait);
        babyAnimal.Initialize(SpeciesTrait, babySize);
        mandatoryTraits.Add(SpeciesTrait);
        mandatoryTraits.Add(babySize);

		babyAnimal.Traits = TraitSelector.selectTraits (mandatoryTraits, this.Traits, mate.Traits);
//
//        List<BaseTrait> babyTraits = new List<BaseTrait>();
//        foreach (BaseTrait trait in traits)
//        {
//            if (trait.getInheritanceChance(babyTotalTraits) >= Random.Range(0f, 1.0f))
//            {
//                babyTraits.Add(trait);
//                babyTotalTraits.Add(trait);
//            }
//        }
//        foreach (BaseTrait trait in mate.traits)
//        {
//            bool compatible = true;
//            foreach (BaseTrait babyTrait in babyTotalTraits)
//            {
//                if (!babyTrait.isCompatible(trait))
//                {
//                    compatible = false;
//                    break;
//                }
//            }
//            if (!compatible)
//            {
//                continue;
//            }
//            if (trait.getInheritanceChance(babyTotalTraits) >= Random.Range(0f, 1.0f))
//            {
//                babyTraits.Add(trait);
//                babyTotalTraits.Add(trait);
//            }
//        }

        return baby;
    }

    public int GetAttributeScore(string attribute)
    {
        int score = 3;

		score += SpeciesTrait.getAttributes(attribute);
		score += SizeTrait.getAttributes(attribute);

        foreach (BaseTrait t in Traits)
        {
			score += t.getAttributes(attribute);
        }

        return score;
    }

    public int GetFoodRequirement()
    {
        return def.SizeTrait.size;
    }

}
