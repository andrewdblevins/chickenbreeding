using UnityEngine;
using System.Collections.Generic;

public class TraitFactory {
    public static Dictionary<string, BaseTrait> instantiatedTraits = 
		new Dictionary<string, BaseTrait> () { };

	public static List<BaseTrait> getInstantiatedTraitValues() {
		
		List<BaseTrait> allTraits = new List<BaseTrait>();

		foreach(KeyValuePair<string, BaseTrait> entry in TraitFactory.instantiatedTraits)
		{
			allTraits.Add (entry.Value);
		}
		return allTraits;
	}

    /** This should only be referenced by data classes. */
    public enum Traits
    {
        Tiny,
        Small,
        Midsized,
        Large,
        Huge,
        Enormous,
        Strong,
        Weak,
        Quick,
        Slow,
        Aggressive,
        Docile,
        Flying,
        KeenEyes,
        Armored,
        Spikes,
        KeenSmell,
        Horned,
        Loyal,
        Independent,
    }

    /** This should only be referenced by data classes. */
    public enum Attribute
    {
        Fighting,
        Strength,
        Tracking,
        Food,
    }

    /** This should only be referenced by data classes. */
    public enum TraitClass
    {
        Size,
        Power,
        Speed,
        Aggression,
        Loyalty,
    }

    public static BaseTrait createStrong()
    {
        if (instantiatedTraits.ContainsKey(Traits.Strong.ToString()))
        {
            return instantiatedTraits[Traits.Strong.ToString()];
        }
        BaseTrait strong = new BaseTrait();
        strong.attributes.Add(Attribute.Fighting.ToString(), 1);
        strong.attributes.Add(Attribute.Strength.ToString(), 2);
        strong.attributes.Add(Attribute.Tracking.ToString(), 0);
        strong.attributes.Add(Attribute.Food.ToString(), 0);

//        strong.inheritanceChance = 1.0f;

        strong.name = Traits.Strong.ToString();
        strong.type = Traits.Strong.ToString();
        strong.traitClass = TraitClass.Power.ToString();

        strong.linkageMap.Add(Traits.Slow.ToString(), 1.0f);
        strong.linkageMap.Add(Traits.Quick.ToString(), -1.0f);

        instantiatedTraits[Traits.Strong.ToString()] = strong;
        return strong;
    }

    public static BaseTrait createWeak()
    {
        if (instantiatedTraits.ContainsKey(Traits.Weak.ToString()))
        {
            return instantiatedTraits[Traits.Weak.ToString()];
        }
        BaseTrait weak = new BaseTrait();
        weak.attributes.Add(Attribute.Fighting.ToString(), -1);
        weak.attributes.Add(Attribute.Strength.ToString(), -2);
        weak.attributes.Add(Attribute.Tracking.ToString(), 0);
        weak.attributes.Add(Attribute.Food.ToString(), 0);

        weak.inheritanceChance = 2.0f;

        weak.name = Traits.Weak.ToString();
        weak.type = Traits.Weak.ToString();
        weak.traitClass = TraitClass.Power.ToString();

        weak.linkageMap.Add(Traits.Quick.ToString(), 0.9f);

        instantiatedTraits[Traits.Weak.ToString()] = weak;
        return weak;
    }

    public static BaseTrait createQuick()
    {
        if (instantiatedTraits.ContainsKey(Traits.Quick.ToString()))
        {
            return instantiatedTraits[Traits.Quick.ToString()];
        }
        BaseTrait quick = new BaseTrait();
        quick.attributes.Add(Attribute.Fighting.ToString(), -1);
        quick.attributes.Add(Attribute.Strength.ToString(), 0);
        quick.attributes.Add(Attribute.Tracking.ToString(), 1);
        quick.attributes.Add(Attribute.Food.ToString(), 0);

//        quick.inheritanceChance = 0.0f;

        quick.name = Traits.Quick.ToString();
        quick.type = Traits.Quick.ToString();
        quick.traitClass = TraitClass.Speed.ToString();

        quick.linkageMap.Add(Traits.Weak.ToString(), 0.9f);

        instantiatedTraits[Traits.Quick.ToString()] = quick;
        return quick;
    }

    public static BaseTrait createSlow()
    {
        if (instantiatedTraits.ContainsKey(Traits.Slow.ToString()))
        {
            return instantiatedTraits[Traits.Slow.ToString()];
        }
        BaseTrait slow = new BaseTrait();
        slow.attributes.Add(Attribute.Fighting.ToString(), -1);
        slow.attributes.Add(Attribute.Strength.ToString(), 0);
        slow.attributes.Add(Attribute.Tracking.ToString(), 0);
        slow.attributes.Add(Attribute.Food.ToString(), 0);

        slow.inheritanceChance = 1.0f;

        slow.name = Traits.Slow.ToString();
        slow.type = Traits.Slow.ToString();
        slow.traitClass = TraitClass.Speed.ToString();

        slow.linkageMap.Add(Traits.Strong.ToString(), 3.0f);

        instantiatedTraits[Traits.Slow.ToString()] = slow;
        return slow;
    }

    public static BaseTrait createAggressive()
    {
        if (instantiatedTraits.ContainsKey(Traits.Aggressive.ToString()))
        {
            return instantiatedTraits[Traits.Aggressive.ToString()];
        }
        BaseTrait aggressive = new BaseTrait();
        aggressive.attributes.Add(Attribute.Fighting.ToString(), 2);
        aggressive.attributes.Add(Attribute.Strength.ToString(), 0);
        aggressive.attributes.Add(Attribute.Tracking.ToString(), 1);
        aggressive.attributes.Add(Attribute.Food.ToString(), 0);

        aggressive.inheritanceChance = 0.1f;

        aggressive.name = Traits.Aggressive.ToString();
        aggressive.type = Traits.Aggressive.ToString();
        aggressive.traitClass = TraitClass.Aggression.ToString();

        aggressive.linkageMap.Add(Traits.Independent.ToString(), 0.1f);
        aggressive.linkageMap.Add(Traits.Loyal.ToString(), -0.2f);

        instantiatedTraits[Traits.Aggressive.ToString()] = aggressive;
        return aggressive;
    }

    public static BaseTrait createDocile()
    {
        string traitString = Traits.Docile.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait docile = new BaseTrait();
        docile.attributes.Add(Attribute.Fighting.ToString(), -2);
        docile.attributes.Add(Attribute.Strength.ToString(), 0);
        docile.attributes.Add(Attribute.Tracking.ToString(), -2);
        docile.attributes.Add(Attribute.Food.ToString(), 0);

        docile.inheritanceChance = 0.1f;

        docile.name = traitString;
        docile.type = traitString;
        docile.traitClass = TraitClass.Aggression.ToString();

        docile.linkageMap.Add(Traits.Independent.ToString(), -0.2f);

        instantiatedTraits[traitString] = docile;
        return docile;
    }

    public static BaseTrait createFlying()
    {
        string traitString = Traits.Flying.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait flying = new BaseTrait();
        flying.attributes.Add(Attribute.Fighting.ToString(), 1);
        flying.attributes.Add(Attribute.Strength.ToString(), 0);
        flying.attributes.Add(Attribute.Tracking.ToString(), 2);
        flying.attributes.Add(Attribute.Food.ToString(), 0);

        flying.inheritanceChance = 0.1f;

        flying.name = traitString;
        flying.type = traitString;
        flying.traitClass = null;

        flying.linkageMap.Add(Traits.Quick.ToString(), 0.2f);
        flying.linkageMap.Add(Traits.KeenEyes.ToString(), 0.4f);

        instantiatedTraits[traitString] = flying;
        return flying;
    }

    public static BaseTrait createKeenEyes()
    {
        string traitString = Traits.KeenEyes.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait keenEyes = new BaseTrait();
        keenEyes.attributes.Add(Attribute.Fighting.ToString(), 1);
        keenEyes.attributes.Add(Attribute.Strength.ToString(), 0);
        keenEyes.attributes.Add(Attribute.Tracking.ToString(), 4);
        keenEyes.attributes.Add(Attribute.Food.ToString(), 0);

        keenEyes.inheritanceChance = 0.1f;

        keenEyes.name = traitString;
        keenEyes.type = traitString;
        keenEyes.traitClass = null;

        keenEyes.linkageMap.Add(Traits.Flying.ToString(), 0.1f);

        instantiatedTraits[traitString] = keenEyes;
        return keenEyes;
    }

    public static BaseTrait createArmored()
    {
        string traitString = Traits.Armored.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait armored = new BaseTrait();
        armored.attributes.Add(Attribute.Fighting.ToString(), 4);
        armored.attributes.Add(Attribute.Strength.ToString(), 1);
        armored.attributes.Add(Attribute.Tracking.ToString(), 0);
        armored.attributes.Add(Attribute.Food.ToString(), 0);

        armored.inheritanceChance = 0.1f;

        armored.name = traitString;
        armored.type = traitString;
        armored.traitClass = null;

        armored.linkageMap.Add(Traits.Strong.ToString(), 0.4f);
        armored.linkageMap.Add(Traits.Quick.ToString(), -0.2f);

        instantiatedTraits[traitString] = armored;
        return armored;
    }

    public static BaseTrait createSpikes()
    {
        string traitString = Traits.Spikes.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait spikes = new BaseTrait();
        spikes.attributes.Add(Attribute.Fighting.ToString(), 4);
        spikes.attributes.Add(Attribute.Strength.ToString(), 1);
        spikes.attributes.Add(Attribute.Tracking.ToString(), 0);
        spikes.attributes.Add(Attribute.Food.ToString(), 0);

        spikes.inheritanceChance = 0.1f;

        spikes.name = traitString;
        spikes.type = traitString;
        spikes.traitClass = null;

        spikes.linkageMap.Add(Traits.Strong.ToString(), 0.2f);
        spikes.linkageMap.Add(Traits.Quick.ToString(), -0.1f);
        spikes.linkageMap.Add(Traits.Aggressive.ToString(), 0.1f);

        instantiatedTraits[traitString] = spikes;
        return spikes;
    }

    public static BaseTrait createKeenSmell()
    {
        string traitString = Traits.KeenSmell.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait keenSmell = new BaseTrait();
        keenSmell.attributes.Add(Attribute.Fighting.ToString(), 0);
        keenSmell.attributes.Add(Attribute.Strength.ToString(), 0);
        keenSmell.attributes.Add(Attribute.Tracking.ToString(), 4);
        keenSmell.attributes.Add(Attribute.Food.ToString(), 0);

        keenSmell.inheritanceChance = 0.1f;

        keenSmell.name = traitString;
        keenSmell.type = traitString;
        keenSmell.traitClass = null;

        instantiatedTraits[traitString] = keenSmell;
        return keenSmell;
    }

    public static BaseTrait createHorned()
    {
        string traitString = Traits.Horned.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait horned = new BaseTrait();
        horned.attributes.Add(Attribute.Fighting.ToString(), 3);
        horned.attributes.Add(Attribute.Strength.ToString(), 1);
        horned.attributes.Add(Attribute.Tracking.ToString(), 0);
        horned.attributes.Add(Attribute.Food.ToString(), 0);

        horned.inheritanceChance = 0.1f;

        horned.name = traitString;
        horned.type = traitString;
        horned.traitClass = null;

        horned.linkageMap.Add(Traits.Armored.ToString(), 0.1f);
        horned.linkageMap.Add(Traits.Aggressive.ToString(), 0.1f);

        instantiatedTraits[traitString] = horned;
        return horned;
    }

    public static BaseTrait createLoyal()
    {
        string traitString = Traits.Loyal.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait loyalty = new BaseTrait();
        loyalty.attributes.Add(Attribute.Fighting.ToString(), 1);
        loyalty.attributes.Add(Attribute.Strength.ToString(), 0);
        loyalty.attributes.Add(Attribute.Tracking.ToString(), 1);
        loyalty.attributes.Add(Attribute.Food.ToString(), 0);

        loyalty.inheritanceChance = 0.1f;

        loyalty.name = traitString;
        loyalty.type = traitString;
        loyalty.traitClass = TraitClass.Loyalty.ToString();

        loyalty.linkageMap.Add(Traits.Docile.ToString(), 0.1f);
        loyalty.linkageMap.Add(Traits.Aggressive.ToString(), -0.1f);

        instantiatedTraits[traitString] = loyalty;
        return loyalty;
    }

    public static BaseTrait createIndependent()
    {
        string traitString = Traits.Independent.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait independent = new BaseTrait();
        independent.attributes.Add(Attribute.Fighting.ToString(), 2);
        independent.attributes.Add(Attribute.Strength.ToString(), 0);
        independent.attributes.Add(Attribute.Tracking.ToString(), 0);
        independent.attributes.Add(Attribute.Food.ToString(), 0);

        independent.inheritanceChance = 0.1f;

        independent.name = traitString;
        independent.type = traitString;
        independent.traitClass = TraitClass.Loyalty.ToString();

        independent.linkageMap.Add(Traits.Docile.ToString(), -0.2f);
        independent.linkageMap.Add(Traits.Aggressive.ToString(), 0.2f);

        instantiatedTraits[traitString] = independent;
        return independent;
    }
}
