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
        SlotBehavior[] slots = transform.parent.GetComponentsInChildren<SlotBehavior>();

        Animal draggedAnimal = DraggableBehaviourScript.ItemBeingDragged.GetComponent<Animal>();

        foreach(SlotBehavior slot in slots)
        {
            if (slot.animal != null)
            {
                Animal slottedAnimal = slot.animal.GetComponent<Animal>();
                if (slottedAnimal != null && !slottedAnimal.CanBreedWith(draggedAnimal))
                {
                    return;
                }
            }
        }
		if (!animal && draggedAnimal.GetAge() != Animal.Age.Baby) {
			DraggableBehaviourScript.ItemBeingDragged.transform.SetParent (transform);
			DraggableBehaviourScript.ItemBeingDragged.transform.position = transform.position;
		}

	}
}
