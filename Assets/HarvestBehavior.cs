using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HarvestBehavior : MonoBehaviour, IDropHandler{

	public void OnDrop (PointerEventData eventData)
	{
		int food = DraggableBehaviourScript.ItemBeingDragged.gameObject.GetComponent<Animal> ().GetAttributeScore("Food");

		GameManager.Instance.AddFood (food);

		Destroy (DraggableBehaviourScript.ItemBeingDragged);
	}		
}
