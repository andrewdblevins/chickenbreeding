using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggableBehaviourScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
	public static GameObject ItemBeingDragged = null;
	Vector3 StartPosition;
	Transform StartParent;


	public void OnBeginDrag (PointerEventData eventData)
	{

		ItemBeingDragged = gameObject;
		StartPosition = transform.position;
		StartParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;

	}
		

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}



	public void OnEndDrag (PointerEventData eventData)
	{
		ItemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == StartParent) {
			transform.position = StartPosition;
		}
	}
}
