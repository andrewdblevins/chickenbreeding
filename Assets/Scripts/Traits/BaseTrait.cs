using UnityEngine;
using System.Collections.Generic;

public class BaseTrait
{
    public Dictionary<string, int> attributes = new Dictionary<string, int>();

    public float inheritanceChance;

    public string name;
    public string type;
    public string traitClass;

    public float getLinkageChance(List<BaseTrait> traits)
    {
        float linkageChance = 0;
        foreach(BaseTrait trait in traits)
        {
            if (linkageMap.ContainsKey(trait.type))
            {
                linkageChance += linkageMap[trait.type];
            }
            if (trait.linkageMap.ContainsKey(type))
            {
                linkageChance += trait.linkageMap[type];
            }
        }
        return linkageChance;
    }

    public float getInheritanceChance(List<BaseTrait> traits)
    {
        return inheritanceChance + getLinkageChance(traits);
    }

    public Dictionary<string, float> linkageMap = new Dictionary<string, float>();

    public virtual bool isCompatible(BaseTrait other)
    {
        return !(this.type == other.type || (traitClass != null && traitClass == other.traitClass));
    }
}
