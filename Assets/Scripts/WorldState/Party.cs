using System;
using System.Collections.Generic;
using UnityEngine;

public class Party
{
    List<GameObject> members = new List<GameObject>();

    public void AddMemeber(GameObject obj)
    {
        members.Add(obj);
    }

    public List<GameObject> GetMembers()
    {
        return members;
    }

    public int Size()
    {
        return members.Count;
    }

    public GameObject RemoveMember(int index)
    {
        GameObject toDie = members[index];
        members.RemoveAt(index);
        return toDie;
    }

    public int GetAttributeScore(string attribute)
    {
        int score = 0;
        foreach (GameObject partyMember in members)
        {
            Animal a = partyMember.GetComponent<Animal>();
            score += Math.Max(a.GetAttributeScore(attribute), 0);
        }
        return score;
    }
}
