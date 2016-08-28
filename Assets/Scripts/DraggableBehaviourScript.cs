﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableBehaviourScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler{
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

	public void OnPointerEnter (PointerEventData eventData)
	{
		InspectPanelBehavior inspectManager = InspectPanelBehavior.Instance;
		inspectManager.gameObject.transform.position = Input.mousePosition;

		Animal animal;
		if (gameObject.GetComponent<Animal>()) {
			animal = (Animal)gameObject.GetComponent<Animal>();

			inspectManager.SetImage( gameObject.GetComponent<Image> ().sprite);
			inspectManager.SetAttrText (animal.GetAttributeScore("Fighting").ToString());

			string traitText;
			traitText = animal.sizeTrait.name.ToString () + "\n";
			traitText = traitText + animal.speciesTrait.name.ToString() + "\n";
			foreach (BaseTrait t in animal.traits) {
				traitText = traitText + t.name.ToString() + "\n";
			}

			inspectManager.SetTraitText (traitText);

			inspectManager.gameObject.SetActive (true);
		}


	}
		
	public void OnPointerExit (PointerEventData eventData)
	{
		InspectPanelBehavior.Instance.gameObject.SetActive (false);
	}
}
