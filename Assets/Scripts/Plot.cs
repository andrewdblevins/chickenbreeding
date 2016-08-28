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
            print("have breeding animals");
            Animal leftAnimal = breedLeft.GetComponentInChildren<Animal>();
            Animal rightAnimal = breedRight.GetComponentInChildren<Animal>();
            if (leftAnimal != null && rightAnimal != null)
            {
                if (leftAnimal.CanBreedWith(rightAnimal))
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

	public void OnDrop (PointerEventData eventData)
	{
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
	