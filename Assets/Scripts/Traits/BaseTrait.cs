using UnityEngine;
using System.Collections.Generic;

public class BaseTrait
{
    public Dictionary<string, int> attributes = new Dictionary<string, int>();

    public float inheritanceChance;

    public string name;
    public string type;
    public string traitClass;

    public Dictionary<string, float> linkageMap = new Dictionary<string, float>();

    public bool isCompatible(BaseTrait other)
    {
        return !(this.type == other.type || traitClass == other.traitClass);
    }
}
