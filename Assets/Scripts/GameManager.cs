using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject panel;
	public Plot plot;

	public GameState getGameState() { return GameState.Instance; }

	public static GameManager Instance;

	private GameManager() {}

	// Use this for initialization
	void Start () {
		foreach (var i in System.Linq.Enumerable.Range(0, 10))
		{
			getGameState ().createPlot ();
		}
	  
	}

	void Awake () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
//		Instantiate(plot);
//		GameState.Instance.iterateTurn ();
	}
}

public class GameState : MonoBehaviour {
	private int turn = 0;

	HashSet<Animal> allAnimals = new HashSet<Animal>();
	HashSet<Plot> allPlots = new HashSet<Plot>();

	enum Season {Spring, Summer, Autumn, Winter};

	Season getSeason() { return (Season)(turn % 4); }

	private static GameState instance;

	private GameState() {
		//Create plots

	}

	public static GameState Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new GameState();
			}
			return instance;
		}
	}


	public Plot createPlot() {
		Plot p = Instantiate (GameManager.Instance.plot);
		p.transform.SetParent(GameManager.Instance.panel.transform);
		allPlots.Add (p);
		return p;
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
		print ("Iterating turn");
		if (preEndTurnChecks()) {
		  turn += 1;
		  managePlots ();
		  manageAnimals ();
		  fireRandomEvent ();
		}
	}
}
