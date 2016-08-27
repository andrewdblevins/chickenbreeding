using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    List<BaseTrait> traits = new List<BaseTrait>();

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

    public GameObject breedWith (Animal mate)
    {
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
}
