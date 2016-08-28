using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HarvestBehavior : MonoBehaviour, IDropHandler{

	public void OnDrop (PointerEventData eventData)
	{
		Destroy (DraggableBehaviourScript.ItemBeingDragged);
	}		
}
