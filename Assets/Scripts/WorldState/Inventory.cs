using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private AnimalFactory animalFactory;

    public UnityEngine.UI.Text foodDisplay;
    public InventoryPanel panel;

    List<GameObject> inventory = new List<GameObject>();
    public int maxSize = 5;

    int curFood = 0;

    public int CurFood
    {
        get
        {
            return curFood;
        }

        set
        {
            curFood = value;
            foodDisplay.text = curFood.ToString();
        }
    }

    public bool subtractFood(int amount)
    {
        CurFood = Math.Max(0, CurFood - amount);
        return CurFood > 0;
    }

    public void Initialize(AnimalFactory animalFactory)
    {
        this.animalFactory = animalFactory;
    }

    internal void AddAll(List<AnimalDef> reward)
    {
        foreach (AnimalDef def in reward)
        {
            panel.Add(animalFactory.createFromDef(def));
        }
    }
}
