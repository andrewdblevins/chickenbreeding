using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    private AnimalDef def = new AnimalDef();
    public Sprite[] animals;
    public GameObject animalPrefab;

    private int age = 0;

    public enum Age { Baby, YoungAdult, Adult, Old };

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

    public Age GetAge()
    {
        if (age < 4)
        {
            return Age.Baby;
        }
        if (age < 8)
        {
            return Age.YoungAdult;
        }
        if (age < 16)
        {
            return Age.Adult;
        }
        return Age.Old;
    }

    public void Initialize(SpeciesTrait species, SizeTrait size) {
		Initialize (species, size, new List<BaseTrait> (), 0);
	}

	public void Initialize(SpeciesTrait species, SizeTrait size, List<BaseTrait> inputTraits, int age)
	{
		SpeciesTrait = species;
		SizeTrait = size;
		Traits = inputTraits;

        Image image = GetComponent<Image>();
        if (image != null)
        {
            image.sprite = animals[species.spriteIndex];
        }
        this.age = age;
        adjustScaleForAge();

        MyEventSystem.OnSeasonAdvance += GetOlder;
    }

    void OnDestroy()
    {
        MyEventSystem.OnSeasonAdvance -= GetOlder;
    }

    private void adjustScaleForAge()
    {
        switch (GetAge())
        {
            case Age.Baby:
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case Age.YoungAdult:
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                break;
            case Age.Adult:
            case Age.Old:
                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
        }
    }

    public void GetOlder()
    {
        age++;
        adjustScaleForAge();
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
