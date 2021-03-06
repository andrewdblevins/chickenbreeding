﻿using UnityEngine;
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
        Swim,
        Climb,
        Stealthy,
        Dig,
        Delicious,
        Marbled,
        Fat,
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

	public static void instantiateAllTraits() {
		TraitFactory.createStrong ();
		TraitFactory.createWeak ();
		TraitFactory.createQuick ();
		TraitFactory.createAggressive ();
		TraitFactory.createDocile ();
		TraitFactory.createSpikes (); 
		TraitFactory.createKeenEyes (); 
		TraitFactory.createKeenSmell (); 
		TraitFactory.createLoyal();
		TraitFactory.createFlying();
		TraitFactory.createHorned();
		TraitFactory.createArmored();
		TraitFactory.createIndependent();
        TraitFactory.createClimb();
        TraitFactory.createDig();
        TraitFactory.createStealthy();
        TraitFactory.createSwim();
        TraitFactory.createMarbled();
        TraitFactory.createDelicious();
        TraitFactory.createFat();
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

        strong.linkageMap.Add(Traits.Slow.ToString(), 3.0f);
        strong.linkageMap.Add(Traits.Quick.ToString(), -3.0f);

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

        weak.inheritanceChance = 0.0f;

        weak.name = Traits.Weak.ToString();
        weak.type = Traits.Weak.ToString();
        weak.traitClass = TraitClass.Power.ToString();

        weak.linkageMap.Add(Traits.Quick.ToString(), 2.0f);

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

        quick.linkageMap.Add(Traits.Weak.ToString(), 2.0f);

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

//        aggressive.inheritanceChance = 0.1f;

        aggressive.name = Traits.Aggressive.ToString();
        aggressive.type = Traits.Aggressive.ToString();
        aggressive.traitClass = TraitClass.Aggression.ToString();

        aggressive.linkageMap.Add(Traits.Independent.ToString(), 1.0f);
        aggressive.linkageMap.Add(Traits.Loyal.ToString(), -2.0f);

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

//        docile.inheritanceChance = 0.1f;

        docile.name = traitString;
        docile.type = traitString;
        docile.traitClass = TraitClass.Aggression.ToString();

        docile.linkageMap.Add(Traits.Independent.ToString(), -2.0f);

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

        flying.inheritanceChance = -2.0f;

        flying.name = traitString;
        flying.type = traitString;
        flying.traitClass = null;

        flying.linkageMap.Add(Traits.Quick.ToString(), 2.0f);
        flying.linkageMap.Add(Traits.KeenEyes.ToString(), 1.0f);

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

//        keenEyes.inheritanceChance = 0.1f;

        keenEyes.name = traitString;
        keenEyes.type = traitString;
        keenEyes.traitClass = null;

        keenEyes.linkageMap.Add(Traits.Flying.ToString(), 1.0f);

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

//        armored.inheritanceChance = 0.1f;

        armored.name = traitString;
        armored.type = traitString;
        armored.traitClass = null;

        armored.linkageMap.Add(Traits.Strong.ToString(), 4.0f);
        armored.linkageMap.Add(Traits.Quick.ToString(), -2.0f);

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

//        spikes.inheritanceChance = 0.1f;

        spikes.name = traitString;
        spikes.type = traitString;
        spikes.traitClass = null;

        spikes.linkageMap.Add(Traits.Strong.ToString(), 2.0f);
        spikes.linkageMap.Add(Traits.Quick.ToString(), -1.0f);
        spikes.linkageMap.Add(Traits.Aggressive.ToString(), 1.0f);

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

//        keenSmell.inheritanceChance = 0.1f;

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
//        horned.attributes.Add(Attribute.Tracking.ToString(), 0);
//        horned.attributes.Add(Attribute.Food.ToString(), 0);
//
//        horned.inheritanceChance = 0.1f;

        horned.name = traitString;
        horned.type = traitString;
        horned.traitClass = null;

        horned.linkageMap.Add(Traits.Armored.ToString(), 1.0f);
        horned.linkageMap.Add(Traits.Aggressive.ToString(), 1.0f);

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

//        loyalty.inheritanceChance = 0.1f;

        loyalty.name = traitString;
        loyalty.type = traitString;
        loyalty.traitClass = TraitClass.Loyalty.ToString();

        loyalty.linkageMap.Add(Traits.Docile.ToString(), 1.0f);
        loyalty.linkageMap.Add(Traits.Aggressive.ToString(), -1.0f);

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

//        independent.inheritanceChance = 0.1f;

        independent.name = traitString;
        independent.type = traitString;
        independent.traitClass = null;

        independent.linkageMap.Add(Traits.Docile.ToString(), -2.0f);
        independent.linkageMap.Add(Traits.Aggressive.ToString(), 2.0f);

        instantiatedTraits[traitString] = independent;
        return independent;
    }

    public static BaseTrait createSwim()
    {
        string traitString = Traits.Swim.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait swim = new BaseTrait();
        swim.attributes.Add(Attribute.Fighting.ToString(), 0);
        swim.attributes.Add(Attribute.Strength.ToString(), 0);
        swim.attributes.Add(Attribute.Tracking.ToString(), 0);
        swim.attributes.Add(Attribute.Food.ToString(), 0);

        //        swim.inheritanceChance = 0.1f;

        swim.name = traitString;
        swim.type = traitString;
        swim.traitClass = null;

        instantiatedTraits[traitString] = swim;
        return swim;
    }

    public static BaseTrait createClimb()
    {
        string traitString = Traits.Climb.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait climb = new BaseTrait();
        climb.attributes.Add(Attribute.Fighting.ToString(), 0);
        climb.attributes.Add(Attribute.Strength.ToString(), 1);
        climb.attributes.Add(Attribute.Tracking.ToString(), 0);
        climb.attributes.Add(Attribute.Food.ToString(), 0);

        //        climb.inheritanceChance = 0.1f;

        climb.name = traitString;
        climb.type = traitString;
        climb.traitClass = null;

        instantiatedTraits[traitString] = climb;
        return climb;
    }

    public static BaseTrait createStealthy()
    {
        string traitString = Traits.Stealthy.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait stealthy = new BaseTrait();
        stealthy.attributes.Add(Attribute.Fighting.ToString(), 2);
        stealthy.attributes.Add(Attribute.Strength.ToString(), 0);
        stealthy.attributes.Add(Attribute.Tracking.ToString(), 3);
        stealthy.attributes.Add(Attribute.Food.ToString(), 0);

        //        stealthy.inheritanceChance = 0.1f;

        stealthy.name = traitString;
        stealthy.type = traitString;
        stealthy.traitClass = null;

        instantiatedTraits[traitString] = stealthy;
        return stealthy;
    }

    public static BaseTrait createDig()
    {
        string traitString = Traits.Dig.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait dig = new BaseTrait();
        dig.attributes.Add(Attribute.Fighting.ToString(), 1);
        dig.attributes.Add(Attribute.Strength.ToString(), 1);
        dig.attributes.Add(Attribute.Tracking.ToString(), 0);
        dig.attributes.Add(Attribute.Food.ToString(), 0);

        //        dig.inheritanceChance = 0.1f;

        dig.name = traitString;
        dig.type = traitString;
        dig.traitClass = null;

        instantiatedTraits[traitString] = dig;
        return dig;
    }

    public static BaseTrait createDelicious()
    {
        string traitString = Traits.Delicious.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait delicious = new BaseTrait();
        delicious.attributes.Add(Attribute.Fighting.ToString(), 0);
        delicious.attributes.Add(Attribute.Strength.ToString(), 0);
        delicious.attributes.Add(Attribute.Tracking.ToString(), 0);
        delicious.attributes.Add(Attribute.Food.ToString(), 3);

        //        delicious.inheritanceChance = 0.1f;

        delicious.name = traitString;
        delicious.type = traitString;
        delicious.traitClass = null;

        instantiatedTraits[traitString] = delicious;
        return delicious;
    }

    public static BaseTrait createMarbled()
    {
        string traitString = Traits.Marbled.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait marbled = new BaseTrait();
        marbled.attributes.Add(Attribute.Fighting.ToString(), 0);
        marbled.attributes.Add(Attribute.Strength.ToString(), 0);
        marbled.attributes.Add(Attribute.Tracking.ToString(), 0);
        marbled.attributes.Add(Attribute.Food.ToString(), 3);

        //        marbled.inheritanceChance = 0.1f;

        marbled.name = traitString;
        marbled.type = traitString;
        marbled.traitClass = null;

        marbled.linkageMap.Add(Traits.Delicious.ToString(), 2.0f);
        marbled.linkageMap.Add(Traits.Fat.ToString(), 2.0f);

        instantiatedTraits[traitString] = marbled;
        return marbled;
    }

    public static BaseTrait createFat()
    {
        string traitString = Traits.Fat.ToString();
        if (instantiatedTraits.ContainsKey(traitString))
        {
            return instantiatedTraits[traitString];
        }
        BaseTrait fat = new BaseTrait();
        fat.attributes.Add(Attribute.Fighting.ToString(), -2);
        fat.attributes.Add(Attribute.Strength.ToString(), -1);
        fat.attributes.Add(Attribute.Tracking.ToString(), -1);
        fat.attributes.Add(Attribute.Food.ToString(), 3);

        //        fat.inheritanceChance = 0.1f;

        fat.name = traitString;
        fat.type = traitString;
        fat.traitClass = null;

        fat.linkageMap.Add(Traits.Delicious.ToString(), 2.0f);
        fat.linkageMap.Add(Traits.Marbled.ToString(), 2.0f);


        instantiatedTraits[traitString] = fat;
        return fat;
    }
}
