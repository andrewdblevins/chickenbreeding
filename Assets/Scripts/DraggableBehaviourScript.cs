using UnityEngine;
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

			string attrText = "Stats";
			attrText = attrText + "\nFighting: " + animal.GetAttributeScore ("Fighting").ToString ();
			attrText = attrText + "\nStrength: " + animal.GetAttributeScore ("Strength").ToString ();
			attrText = attrText + "\nTracking: " + animal.GetAttributeScore ("Tracking").ToString ();
			attrText = attrText + "\nFood:     " + animal.GetAttributeScore ("Food").ToString ();

			inspectManager.SetAttrText (attrText);

			string traitText;
			traitText = animal.SizeTrait.name.ToString () + "\n";
			traitText = traitText + animal.SpeciesTrait.name.ToString() + "\n";
			foreach (BaseTrait t in animal.Traits) {
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
