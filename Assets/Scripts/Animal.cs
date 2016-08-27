using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    public SpecialTrait speciesTrait;
    SpecialTrait sizeTrait;
    List<BaseTrait> traits = new List<BaseTrait>();

    public Sprite[] animals;
    public GameObject animalPrefab;

    public void Initialize(SpeciesTrait species, SizeTrait size)
    {
        speciesTrait = species;
        sizeTrait = size;

        Image image = GetComponent<Image>();
        image.sprite = animals[species.spriteIndex];
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

        List<BaseTrait> babyTotalTraits = new List<BaseTrait>();
        babyAnimal.speciesTrait = speciesTrait;
        babyTotalTraits.Add(speciesTrait);

        if (sizeTrait.getInheritanceChance(babyTotalTraits) >= Random.Range(0f, 1.0f))
        {
            babyAnimal.sizeTrait = sizeTrait;
            babyTotalTraits.Add(sizeTrait);
        } else
        {
            babyAnimal.sizeTrait = mate.sizeTrait;
            babyTotalTraits.Add(mate.sizeTrait);
        }

        List<BaseTrait> babyTraits = new List<BaseTrait>();
        foreach (BaseTrait trait in traits)
        {
            if (trait.getInheritanceChance(babyTotalTraits) >= Random.Range(0f, 1.0f))
            {
                babyTraits.Add(trait);
                babyTotalTraits.Add(trait);
            }
        }
        foreach (BaseTrait trait in mate.traits)
        {
            bool compatible = true;
            foreach (BaseTrait babyTrait in babyTotalTraits)
            {
                if (!babyTrait.isCompatible(trait))
                {
                    compatible = false;
                    break;
                }
            }
            if (!compatible)
            {
                continue;
            }
            if (trait.getInheritanceChance(babyTotalTraits) >= Random.Range(0f, 1.0f))
            {
                babyTraits.Add(trait);
                babyTotalTraits.Add(trait);
            }
        }

        babyAnimal.traits = babyTraits;
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
