using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour {
    Party party = new Party();
    Inventory inventory = new Inventory();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Party GetParty()
    {
        return party;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }
}
