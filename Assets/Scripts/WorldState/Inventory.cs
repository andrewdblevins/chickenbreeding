using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private AnimalFactory animalFactory;

    List<GameObject> inventory = new List<GameObject>();

    public void Initialize(AnimalFactory animalFactory)
    {
        this.animalFactory = animalFactory;
    }

    internal void AddAll(List<AnimalDef> reward)
    {
        foreach (AnimalDef def in reward)
        {
            inventory.Add(animalFactory.createFromDef(def));
        }
    }
}
