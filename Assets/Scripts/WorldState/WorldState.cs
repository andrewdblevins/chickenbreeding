using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour {
    public Party party;
    public Inventory inventory;

    public void Initialize(AnimalFactory animalFactory)
    {
        inventory.Initialize(animalFactory);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Party GetParty()
    {
        if (party == null)
        {
            Debug.Log("WTF, where the party at?");
        }
        return party;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }
}
