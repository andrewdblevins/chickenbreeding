using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OptionButtonBehavior : MonoBehaviour, IPointerClickHandler{

	public int optionNum;
	public ExploreState state;

	public void OnPointerClick (PointerEventData eventData)
	{
		Debug.Log("Button pushed");
		state.attempt (optionNum);
	}
		
}
