using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GoExplore : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoExploring(string where)
    {
        switch (where)
        {
            case "forest":
                GameManager.Instance.goExplore(GameManager.ExploreRegion.Forest);
                break;
            case "jungle":
                GameManager.Instance.goExplore(GameManager.ExploreRegion.Jungle);
                break;
            case "grasslands":
                GameManager.Instance.goExplore(GameManager.ExploreRegion.Grassland);
                break;
            case "savana":
                GameManager.Instance.goExplore(GameManager.ExploreRegion.Savana);
                break;
            case "mountain":
                GameManager.Instance.goExplore(GameManager.ExploreRegion.Mountain);
                break;
            case "riverlands":
            default:
                GameManager.Instance.goExplore(GameManager.ExploreRegion.Riverlands);
                break;
        }
    }
}
