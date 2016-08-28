using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GoExplore : MonoBehaviour, IPointerClickHandler
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.goExplore();
    }
}
