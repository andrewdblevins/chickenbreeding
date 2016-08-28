using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour, IDropHandler{

    public GameObject breedLeft;
    public GameObject breedRight;

    public void Breed()
    {
        if (breedLeft != null && breedRight != null)
        {
            Animal leftAnimal = breedLeft.GetComponentInChildren<Animal>();
            Animal rightAnimal = breedRight.GetComponentInChildren<Animal>();
            if (leftAnimal != null && rightAnimal != null)
            {
                print("have actual animals");
                if (leftAnimal.CanBreedWith(rightAnimal) && !IsFull())
                {
                    GameObject baby = leftAnimal.breedWith(rightAnimal);
                    if (baby != null)
                    {
						addAnimal(baby);
                    }
                }
            }
        }
    }

    public bool IsFull()
    {
        return transform.childCount >= 25;
    }

	public void OnDrop (PointerEventData eventData)
	{
        if (IsFull())
        {
            return;
        }
		GameObject animal = DraggableBehaviourScript.ItemBeingDragged;
		this.addAnimal (animal);
	}

	public void addAnimal(GameObject animal){
		animal.transform.SetParent (transform);
        animal.transform.position = transform.position;
	}
		

	public List<GameObject> getAnimalsInPlot(){
		List<GameObject> animalsInPlot = new List<GameObject> ();
		foreach (Transform child in transform){
			animalsInPlot.Add (child.gameObject);
		}
		return animalsInPlot;
	}

}
	