using UnityEngine;
using UnityEngine.EventSystems;

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
        print("explore clicked");
        GameManager.Instance.goExplore();
    }
}
