using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public SpecialTrait speciesTrait;
    SpecialTrait sizeTrait;
    List<BaseTrait> traits = new List<BaseTrait>();

    public void Initialize(SpecialTrait species, SpecialTrait size)
    {
        speciesTrait = species;
        sizeTrait = size;
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
        List<BaseTrait> babyTraits = new List<BaseTrait>();
        foreach (BaseTrait trait in traits)
        {
            if (trait.inheritanceChance >= Random.Range(0f, 1.0f))
            {
                babyTraits.Add(trait);
            }
        }
        foreach (BaseTrait trait in mate.traits)
        {
            bool compatible = true;
            foreach (BaseTrait babyTrait in babyTraits)
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
            if (trait.inheritanceChance >= Random.Range(0f, 1.0f))
            {
                babyTraits.Add(trait);
            }
        }
        GameObject baby = new GameObject();
        baby.AddComponent<Animal>().traits = babyTraits;
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
