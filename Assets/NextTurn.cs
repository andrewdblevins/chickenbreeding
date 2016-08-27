using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class NextTurn : MonoBehaviour, IPointerClickHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region IPointerClickHandler implementation

	public void OnPointerClick (PointerEventData eventData)
	{
		GameState.Instance.iterateTurn ();
	}

	#endregion
}
