using UnityEngine;
using System.Collections.Generic;

public class BaseTrait
{
	//TODO: This should really be private
    public Dictionary<string, int> attributes = new Dictionary<string, int>();

    public float inheritanceChance = 0.0f;

    public string name;
    public string type;
    public string traitClass;

	public int getAttributes(string key) {
		int outValue;
		attributes.TryGetValue (key, out outValue);
		return outValue;
	}

	public void addLinkage(TraitFactory.Traits trt) {
		addLinkage (trt, 1.0f);
	}

	public void addLinkage(TraitFactory.Traits trt, float weight) {
		addLinkage (trt.ToString(), weight);
	}

	public void addLinkage(string trt, float weight) {
		this.linkageMap.Add (trt, weight);
	}

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

	public virtual bool isCompatible(List<BaseTrait> traitList)
	{
		foreach (BaseTrait trait in traitList) {
			if (!this.isCompatible (trait)) {
				return false;
			}
		}
		return true;
	}

    public virtual bool isCompatible(BaseTrait other)
    {
        return !(this.type == other.type || (traitClass != null && traitClass == other.traitClass));
    }
}
