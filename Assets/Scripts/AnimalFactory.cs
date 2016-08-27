using UnityEngine;
using System.Collections;

public class AnimalFactory {

    public GameObject animalPrefab;

    public GameObject createWolf()
    {
        GameObject wolf = GameObject.Instantiate(animalPrefab);
        Animal wolfAnimal = wolf.GetComponent<Animal>();
        wolfAnimal.Initialize(SpeciesFactory.createWolf(), SizeFactory.createMidsized());
        // TODO: add other traits- maybe randomized?
        return wolf;
    }

    public GameObject createRabbit()
    {
        GameObject rabbit = GameObject.Instantiate(animalPrefab);
        Animal rabbitAnimal = rabbit.GetComponent<Animal>();
        rabbitAnimal.Initialize(SpeciesFactory.createRabbit(), SizeFactory.createTiny());
        // TODO: add other traits- maybe randomized?
        return rabbit;
    }

    public GameObject createChicken()
    {
        GameObject chicken = GameObject.Instantiate(animalPrefab);
        Animal chickenAnimal = chicken.GetComponent<Animal>();
        chickenAnimal.Initialize(SpeciesFactory.createChicken(), SizeFactory.createTiny());
        // TODO: add other traits- maybe randomized?
        return chicken;
    }
}
