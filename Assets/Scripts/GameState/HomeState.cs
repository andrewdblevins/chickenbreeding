using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeState : BaseState {
    List<Animal> allAnimals = new List<Animal>();
    List<Plot> allPlots = new List<Plot>();

    private int turn = 0;

    enum Season { Spring, Summer, Autumn, Winter };

    Season getSeason() { return (Season)(turn % 4); }

    public HomeState()
    {

    }

    public void Initialize()
    {
        //Create N plots and M animals in the first plot
        int n = 9;
        int m = 2;
        foreach (var i in System.Linq.Enumerable.Range(0, n))
        {
            createPlot();
        }
        foreach (var i in System.Linq.Enumerable.Range(0, m))
        {
            //Get a plot
            getSomePlot().addAnimal(AnimalFactory.Instance.createChicken());
        }
    }

    public Plot createPlot()
    {
        Plot p = GameObject.Instantiate(GameManager.Instance.plot);
        p.transform.SetParent(GameManager.Instance.panel.transform);
        allPlots.Add(p);
        return p;
    }

    public Plot getSomePlot()
    {
        return allPlots[0];
    }

    public void registerAnimal(Animal a)
    {
        allAnimals.Add(a);
    }

    public void removeAnimal(Animal a)
    {
        allAnimals.Remove(a);
    }

    void manageAnimals()
    {
        foreach (Animal a in allAnimals)
        {

        }
    }

    void managePlots()
    {
        foreach (Plot p in allPlots)
        {
            p.Breed();
        }
    }

    public void iterateTurn()
    {
        if (preEndTurnChecks())
        {
            turn += 1;
            managePlots();
            manageAnimals();
            fireRandomEvent();
        }
    }

    void fireRandomEvent()
    {
        //TODO
    }

    bool preEndTurnChecks()
    {
        //TODO: Check if anything needs to be done by user
        return true;
    }
}
