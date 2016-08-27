using UnityEngine;
using System.Collections.Generic;

public class TraitFactory {
    static Dictionary<string, BaseTrait> instantiatedTraits = new Dictionary<string, BaseTrait>();

    enum Traits
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

    enum Attribute
    {
        Fighting,
        Strength,
        Tracking,
        Food,
    }

    enum TraitClass
    {
        Size,
        Power,
    }

    public static BaseTrait createTiny()
    {
        if (instantiatedTraits.ContainsKey(Traits.Tiny.ToString()))
        {
            return instantiatedTraits[Traits.Tiny.ToString()];
        }
        BaseTrait tiny = new BaseTrait();
        tiny.attributes.Add(Attribute.Fighting.ToString(), -1);
        tiny.attributes.Add(Attribute.Strength.ToString(), 0);
        tiny.attributes.Add(Attribute.Tracking.ToString(), 0);
        tiny.attributes.Add(Attribute.Food.ToString(), 0);

        tiny.inheritanceChance = 0.5f;

        tiny.name = Traits.Tiny.ToString();
        tiny.type = Traits.Tiny.ToString();
        tiny.traitClass = TraitClass.Size.ToString();

        tiny.linkageMap.Add(Traits.Strong.ToString(), -0.4f);
        tiny.linkageMap.Add(Traits.Weak.ToString(), 0.4f);
        tiny.linkageMap.Add(Traits.SlowBreeding.ToString(), -0.4f);
        tiny.linkageMap.Add(Traits.Slow.ToString(), -0.4f);
        tiny.linkageMap.Add(Traits.Quick.ToString(), 0.4f);

        instantiatedTraits[Traits.Tiny.ToString()] = tiny;
        return tiny;
    }

    public static BaseTrait createSmall()
    {
        if (instantiatedTraits.ContainsKey(Traits.Small.ToString()))
        {
            return instantiatedTraits[Traits.Small.ToString()];
        }
        BaseTrait small = new BaseTrait();
        small.attributes.Add(Attribute.Fighting.ToString(), 0);
        small.attributes.Add(Attribute.Strength.ToString(), 0);
        small.attributes.Add(Attribute.Tracking.ToString(), 0);
        small.attributes.Add(Attribute.Food.ToString(), 1);


        small.inheritanceChance = 0.5f;

        small.name = Traits.Small.ToString();
        small.type = Traits.Small.ToString();
        small.traitClass = TraitClass.Size.ToString();

        small.linkageMap.Add(Traits.Strong.ToString(), -0.2f);
        small.linkageMap.Add(Traits.Weak.ToString(), 0.2f);
        small.linkageMap.Add(Traits.SlowBreeding.ToString(), -0.2f);
        small.linkageMap.Add(Traits.Slow.ToString(), -0.2f);
        small.linkageMap.Add(Traits.Quick.ToString(), 0.2f);

        instantiatedTraits[Traits.Small.ToString()] = small;
        return small;
    }

    public static BaseTrait createMidsized()
    {
        if (instantiatedTraits.ContainsKey(Traits.Midsized.ToString()))
        {
            return instantiatedTraits[Traits.Midsized.ToString()];
        }
        BaseTrait midsized = new BaseTrait();
        midsized.attributes.Add(Attribute.Fighting.ToString(), 1);
        midsized.attributes.Add(Attribute.Strength.ToString(), 0);
        midsized.attributes.Add(Attribute.Tracking.ToString(), 0);
        midsized.attributes.Add(Attribute.Food.ToString(), 2);

        midsized.inheritanceChance = 0.5f;

        midsized.name = Traits.Midsized.ToString();
        midsized.type = Traits.Midsized.ToString();
        midsized.traitClass = TraitClass.Size.ToString();

        instantiatedTraits[Traits.Midsized.ToString()] = midsized;
        return midsized;
    }

    public static BaseTrait createLarge()
    {
        if (instantiatedTraits.ContainsKey(Traits.Large.ToString()))
        {
            return instantiatedTraits[Traits.Large.ToString()];
        }
        BaseTrait large = new BaseTrait();
        large.attributes.Add(Attribute.Fighting.ToString(), 1);
        large.attributes.Add(Attribute.Strength.ToString(), 1);
        large.attributes.Add(Attribute.Tracking.ToString(), 0);
        large.attributes.Add(Attribute.Food.ToString(), 3);

        large.inheritanceChance = 0.5f;

        large.name = Traits.Large.ToString();
        large.type = Traits.Large.ToString();
        large.traitClass = TraitClass.Size.ToString();

        large.linkageMap.Add(Traits.Strong.ToString(), 0.2f);
        large.linkageMap.Add(Traits.Weak.ToString(), -0.2f);
        large.linkageMap.Add(Traits.SlowBreeding.ToString(), 0.2f);
        large.linkageMap.Add(Traits.Slow.ToString(), 0.2f);
        large.linkageMap.Add(Traits.Quick.ToString(), -0.2f);

        instantiatedTraits[Traits.Large.ToString()] = large;
        return large;
    }

    public static BaseTrait createHuge()
    {
        if (instantiatedTraits.ContainsKey(Traits.Huge.ToString()))
        {
            return instantiatedTraits[Traits.Huge.ToString()];
        }
        BaseTrait huge = new BaseTrait();
        huge.attributes.Add(Attribute.Fighting.ToString(), 2);
        huge.attributes.Add(Attribute.Strength.ToString(), 2);
        huge.attributes.Add(Attribute.Tracking.ToString(), 0);
        huge.attributes.Add(Attribute.Food.ToString(), 4);

        huge.inheritanceChance = 0.5f;

        huge.name = Traits.Huge.ToString();
        huge.type = Traits.Huge.ToString();
        huge.traitClass = TraitClass.Size.ToString();

        huge.linkageMap.Add(Traits.Strong.ToString(), 0.4f);
        huge.linkageMap.Add(Traits.Weak.ToString(), -0.4f);
        huge.linkageMap.Add(Traits.SlowBreeding.ToString(), 0.4f);
        huge.linkageMap.Add(Traits.Slow.ToString(), 0.4f);
        huge.linkageMap.Add(Traits.Quick.ToString(), -0.4f);

        instantiatedTraits[Traits.Huge.ToString()] = huge;
        return huge;
    }

    public static BaseTrait createEnormous()
    {
        if (instantiatedTraits.ContainsKey(Traits.Enormous.ToString()))
        {
            return instantiatedTraits[Traits.Enormous.ToString()];
        }
        BaseTrait enormous = new BaseTrait();
        enormous.attributes.Add(Attribute.Fighting.ToString(), 3);
        enormous.attributes.Add(Attribute.Strength.ToString(), 3);
        enormous.attributes.Add(Attribute.Tracking.ToString(), 0);
        enormous.attributes.Add(Attribute.Food.ToString(), 6);

        enormous.inheritanceChance = 0.5f;

        enormous.name = Traits.Enormous.ToString();
        enormous.type = Traits.Enormous.ToString();
        enormous.traitClass = TraitClass.Size.ToString();

        enormous.linkageMap.Add(Traits.Strong.ToString(), 0.6f);
        enormous.linkageMap.Add(Traits.Weak.ToString(), -0.6f);
        enormous.linkageMap.Add(Traits.SlowBreeding.ToString(), 0.6f);
        enormous.linkageMap.Add(Traits.Slow.ToString(), 0.6f);
        enormous.linkageMap.Add(Traits.Quick.ToString(), -0.6f);

        instantiatedTraits[Traits.Enormous.ToString()] = enormous;
        return enormous;
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
