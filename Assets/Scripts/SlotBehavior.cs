using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SlotBehavior : MonoBehaviour, IDropHandler{
	public GameObject animal{
		get{ 
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

	public void OnDrop (PointerEventData eventData)
	{
        Animal draggedAnimal = DraggableBehaviourScript.ItemBeingDragged.GetComponent<Animal>();
		if (!animal && draggedAnimal.GetAge() != Animal.Age.Baby) {
			DraggableBehaviourScript.ItemBeingDragged.transform.SetParent (transform);
			DraggableBehaviourScript.ItemBeingDragged.transform.position = transform.position;
		}

	}
}
