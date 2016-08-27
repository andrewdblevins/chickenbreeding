using UnityEngine;
using System.Collections.Generic;

public class TraitFactory {
    static Dictionary<string, BaseTrait> instantiatedTraits = new Dictionary<string, BaseTrait>();

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
        Horny,
        Horned,
        QuickBreeding,
        SlowBreeding,
        MultiOffspring,
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

        strong.inheritanceChance = 0.5f;

        strong.name = Traits.Strong.ToString();
        strong.type = Traits.Strong.ToString();
        strong.traitClass = TraitClass.Power.ToString();

        strong.linkageMap.Add(Traits.SlowBreeding.ToString(), 0.1f);
        strong.linkageMap.Add(Traits.Slow.ToString(), 0.2f);
        strong.linkageMap.Add(Traits.Quick.ToString(), -0.1f);

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

        weak.inheritanceChance = 0.5f;

        weak.name = Traits.Weak.ToString();
        weak.type = Traits.Weak.ToString();
        weak.traitClass = TraitClass.Power.ToString();

        weak.linkageMap.Add(Traits.Quick.ToString(), -0.1f);

        instantiatedTraits[Traits.Weak.ToString()] = weak;
        return weak;
    }
}
