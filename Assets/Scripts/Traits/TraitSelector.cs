using UnityEngine;
using System.Collections.Generic;

public static class TraitSelector
{
	public static List<T> Randomize<T>(List<T> list)
	{
		List<T> randomizedList = new List<T>();
//		Random rnd = new Random();
		while (list.Count > 0)
		{
			int index = Random.Range (0, list.Count);
			randomizedList.Add(list[index]); //place it at the end of the randomized list
			list.RemoveAt(index);
		}
		return randomizedList;
	}

	private static float logistic(float val) {
		return 1.0f / (1.0f + Mathf.Exp(-val));
	}

	static float baseInheritance = -4.0f;
	static float perAdditionalTraitChance = -1.0f;

	public static List<BaseTrait> selectTraits(List<BaseTrait> mandatoryTraits) {
		return selectTraits (mandatoryTraits, new List<BaseTrait> (), new List<BaseTrait> ());
	}

	public static List<BaseTrait> selectTraits(List<BaseTrait> mandatoryTraits, List<BaseTrait> firstParentTraits, List<BaseTrait> secondParentTraits) {
		List<BaseTrait> inheritableTraits = new List<BaseTrait>();

		foreach (BaseTrait trait in Randomize(TraitFactory.getInstantiatedTraitValues())) {
			if (!trait.isCompatible (mandatoryTraits) || !trait.isCompatible (inheritableTraits)) {
				continue;
			}
			float probability = baseInheritance;
			if (firstParentTraits.Contains (trait)) {
				probability += trait.tenacity;
			}
			if (secondParentTraits.Contains (trait)) {
				probability += trait.tenacity;
			}
			probability += trait.inheritanceChance;
			probability += trait.getLinkageChance (mandatoryTraits);
			probability += trait.getLinkageChance (inheritableTraits);
			//TODO: Add species chance
			probability += inheritableTraits.Count * perAdditionalTraitChance;
			GameManager.print (logistic(probability));
			if (Random.value < logistic(probability)) { inheritableTraits.Add (trait); }
		}
		return inheritableTraits;
	}
}


