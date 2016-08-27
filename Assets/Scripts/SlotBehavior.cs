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
		if (!animal) {
			DraggableBehaviourScript.ItemBeingDragged.transform.SetParent (transform);
		}
	}
}
