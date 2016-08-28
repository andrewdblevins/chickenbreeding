using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Party : MonoBehaviour, IDropHandler
{
    //List<GameObject> members = new List<GameObject>();

    //public void AddMemeber(GameObject obj)
    //{
    //    members.Add(obj);
    //}

    private int maxSize = 4;

    public List<GameObject> GetMembers()
    {
        Debug.Log(null);
        Debug.Log("Foo === bar === baz");

        Debug.Log(gameObject);
        Debug.Log(transform);

        List<GameObject> members = new List<GameObject>();

        foreach (Transform child in gameObject.transform)
        {
            members.Add(child.gameObject);
        }
        return members;
    }

    public int Size()
    {
        return transform.childCount;
    }

    public GameObject RemoveMember(int index)
    {
        Transform toDie = transform.GetChild(index);
        toDie.parent = null;
        return toDie.gameObject;
    }

    public int GetAttributeScore(string attribute)
    {
        int score = 0;
        foreach (Transform member in transform)
        {
            GameObject partyMember = member.gameObject;
            Animal a = partyMember.GetComponent<Animal>();
            score += Math.Max(a.GetAttributeScore(attribute), 0);
        }
        return score;
    }

    public int GetFoodRequirement()
    {
        int requirement = 0;
        foreach (Transform member in transform)
        {
            GameObject partyMember = member.gameObject;
            Animal a = partyMember.GetComponent<Animal>();
            requirement += a.GetFoodRequirement();
        }
        return requirement;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (Size() < maxSize)
        {
            DraggableBehaviourScript.ItemBeingDragged.transform.SetParent(transform);
            DraggableBehaviourScript.ItemBeingDragged.transform.position = transform.position;
        }
    }
}
