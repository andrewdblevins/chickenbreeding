using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour {

	public GameObject panel;
	public Plot plot;

	public static GameManager Instance;

    private WorldState worldState = new WorldState();

    private HomeState homeState;
    private BaseState activeState;

	private GameManager() {}

	// Use this for initialization
	void Start () {
        homeState = new HomeState();
        homeState.Initialize();
        activeState = homeState;

		TraitFactory.createStrong ();
		TraitFactory.createWeak ();
		TraitFactory.createQuick ();
		TraitFactory.createAggressive ();
		TraitFactory.createSpikes ();  
	}

    internal void goExplore()
    {
        print("go explore clicked");
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
}
