using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour {

	public GameObject panel;
	public Plot plot;
    public ExplorationController explorationController;

	public static GameManager Instance;

    private WorldState worldState = new WorldState();

    private BaseState state;

	private GameManager() {}

	// Use this for initialization
	void Start () {
        state = new HomeState();
		//Create N plots and M animals in the first plot
		int n = 10;
		int m = 2;
		foreach (var i in System.Linq.Enumerable.Range(0, n))
		{
			createPlot ();
		}
		foreach (var i in System.Linq.Enumerable.Range(0, m))
		{
			//Get a plot
			getSomePlot().addAnimal(AnimalFactory.Instance.createChicken());
		}
	  
	}

    internal void goExplore()
    {
        explorationController.StartExploration(worldState);
    }

    void Awake () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
//		Instantiate(plot);
//		GameState.Instance.iterateTurn ();
	}

	private int turn = 0;

	List<Animal> allAnimals = new List<Animal>();
	List<Plot> allPlots = new List<Plot>();

	enum Season {Spring, Summer, Autumn, Winter};

	Season getSeason() { return (Season)(turn % 4); }

	public Plot createPlot() {
		Plot p = Instantiate (GameManager.Instance.plot);
		p.transform.SetParent(GameManager.Instance.panel.transform);
		allPlots.Add (p);
		return p;
	}

	public Plot getSomePlot() {
		return allPlots [0];
	}

	public void registerAnimal(Animal a) {
		allAnimals.Add (a);
	}

	public void removeAnimal(Animal a) {
		allAnimals.Remove (a);
	}

	void manageAnimals() {
		foreach (Animal a in allAnimals) {

		}
	}

	void managePlots() {
		foreach (Plot p in allPlots) {
			p.Breed ();
		}
	}

	void fireRandomEvent() {
		//TODO
	}

	bool preEndTurnChecks() {
		//TODO: Check if anything needs to be done by user
		return true;
	}

	public void iterateTurn() {
		if (preEndTurnChecks()) {
			turn += 1;
			managePlots ();
			manageAnimals ();
			fireRandomEvent ();
		}
	}
}
