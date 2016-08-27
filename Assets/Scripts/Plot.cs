using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour, IDropHandler{

    GameObject breedLeft;
    GameObject breedRight;

    List<GameObject> babies = new List<GameObject>();

	// Use this for initialization
	void Start () {
        // Uncomment here and the Breed call in Update to see breeding in action.
        //breedLeft = new GameObject();
        //Animal leftAnimal = breedLeft.AddComponent<Animal>();
        //leftAnimal.AddTrait(TraitFactory.createLarge());
        //leftAnimal.AddTrait(TraitFactory.createStrong());
        //breedRight = new GameObject();
        //Animal rightAnimal = breedRight.AddComponent<Animal>();
        //rightAnimal.AddTrait(TraitFactory.createEnormous());
        //rightAnimal.AddTrait(TraitFactory.createWeak());
    }
	
	// Update is called once per frame
	void Update () {
        // Uncomment here and the animal creation in Start to see breeding in action.
        //Breed();
	}

    void Breed()
    {
        if (breedLeft != null && breedRight != null)
        {
            Animal leftAnimal = breedLeft.GetComponent<Animal>();
            Animal rightAnimal = breedRight.GetComponent<Animal>();
            if (leftAnimal != null && rightAnimal != null)
            {
                babies.Add(leftAnimal.breedWith(rightAnimal));
            }
        }
    }
		

	public void OnDrop (PointerEventData eventData)
	{
		DraggableBehaviourScript.ItemBeingDragged.transform.SetParent (transform);
	}

}
	