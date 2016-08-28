using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    public SpecialTrait speciesTrait;
    public SpecialTrait sizeTrait;
    public List<BaseTrait> traits = new List<BaseTrait>();

    public Sprite[] animals;
    public GameObject animalPrefab;

    public void Initialize(SpeciesTrait species, SizeTrait size)
    {
        speciesTrait = species;
        sizeTrait = size;

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
        traits.Add(trait);
    }

    public bool CanBreedWith(Animal mate)
    {
        return speciesTrait.isCompatible(mate.speciesTrait) && sizeTrait.isCompatible(mate.sizeTrait);
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
        babyAnimal.speciesTrait = speciesTrait;
		mandatoryTraits.Add(speciesTrait);

		//TODO: Something about this doesn't quite make sense for the size trait
		if (sizeTrait.getInheritanceChance(mandatoryTraits) >= Random.Range(0f, 1.0f))
        {
            babyAnimal.sizeTrait = sizeTrait;
			mandatoryTraits.Add(sizeTrait);
        } else
        {
            babyAnimal.sizeTrait = mate.sizeTrait;
			mandatoryTraits.Add(mate.sizeTrait);
        }

		babyAnimal.traits = TraitSelector.selectTraits (mandatoryTraits, this.traits, mate.traits);
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
        int score = 0;

        score += speciesTrait.attributes[attribute];
        score += sizeTrait.attributes[attribute];

        foreach (BaseTrait t in traits)
        {
            score += t.attributes[attribute];
        }

        return score;
    }

}
