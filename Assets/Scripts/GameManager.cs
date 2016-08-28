using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour {

	public GameObject panel;
	public Plot plot;

	public static GameManager Instance;

    public WorldState worldState;// = new WorldState();

    private HomeState homeState;
    private BaseState activeState;

	private GameManager() {}

	// Use this for initialization
	void Start () {
        //worldState = new WorldState();
        AnimalFactory animalFactory = GetComponent<AnimalFactory>();
        worldState.Initialize(animalFactory);

        TraitFactory.instantiateAllTraits();

        homeState = new HomeState();
        homeState.Initialize();
        activeState = homeState;
	}

    internal void goExplore()
    {
        ExploreState exploreState = new ExploreState();
        exploreState.StartExploration(worldState);
        activeState = exploreState;
    }

    void Awake () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        activeState.Step();
	}

    // TODO move the next button to be controlled by home state being the active state.
    public void iterateTurn()
    {
        homeState.iterateTurn();
    }

    internal void GoHome()
    {
        activeState = homeState;
    }

	public void AddFood(int food){
		worldState.GetInventory ().CurFood += food;
		print (worldState.GetInventory ().CurFood);
	}
}
