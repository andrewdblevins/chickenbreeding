using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class InventoryPanel : MonoBehaviour, IDropHandler
{
    Inventory inventory;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount < inventory.maxSize)
        {
            DraggableBehaviourScript.ItemBeingDragged.transform.SetParent(transform);
            DraggableBehaviourScript.ItemBeingDragged.transform.position = transform.position;
        }
    }

    public void Add(GameObject obj)
    {
        if (transform.childCount < inventory.maxSize)
        {
            obj.transform.parent = transform;
        } else
        {
            Destroy(obj);
        }
    }

    // Use this for initialization
    void Awake () {
        inventory = transform.parent.gameObject.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {

    }
}
