using UnityEngine;
using System.Collections.Generic;

public class SizeFactory {
    static Dictionary<string, SizeTrait> instantiatedTraits = new Dictionary<string, SizeTrait>();

    public static List<SizeTrait> GetAllSizeTraits()
    {
        List<SizeTrait> sizes = new List<SizeTrait>();
        sizes.Add(createTiny());
        sizes.Add(createSmall());
        sizes.Add(createMidsized());
        sizes.Add(createLarge());
        sizes.Add(createHuge());
        sizes.Add(createEnormous());
        return sizes;
    }

    enum Size : int
    {
        Tiny = 0,
        Small = 1,
        Midsized = 2,
        Large = 3,
        Huge = 4,
        Enormous = 5,
    }

    public static SizeTrait createTiny()
    {
        if (instantiatedTraits.ContainsKey(TraitFactory.Traits.Tiny.ToString()))
        {
            return instantiatedTraits[TraitFactory.Traits.Tiny.ToString()];
        }
        SizeTrait tiny = new SizeTrait();
        tiny.size = (int)Size.Tiny;
        tiny.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), -1);
        tiny.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 0);
        tiny.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        tiny.attributes.Add(TraitFactory.Attribute.Food.ToString(), 0);

        tiny.inheritanceChance = 0.5f;

        tiny.name = TraitFactory.Traits.Tiny.ToString();
        tiny.type = TraitFactory.Traits.Tiny.ToString();
        tiny.traitClass = TraitFactory.TraitClass.Size.ToString();

        tiny.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), -2.0f);
        tiny.linkageMap.Add(TraitFactory.Traits.Weak.ToString(), 1.5f);
        tiny.linkageMap.Add(TraitFactory.Traits.Slow.ToString(), -2.0f);
        tiny.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 1.5f);
		tiny.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), 0.5f);

        tiny.linkageMap.Add(Size.Tiny.ToString(), 1.5f);
        tiny.linkageMap.Add(Size.Small.ToString(), 0.5f);

        instantiatedTraits[TraitFactory.Traits.Tiny.ToString()] = tiny;
        return tiny;
    }

    public static SizeTrait createSmall()
    {
        if (instantiatedTraits.ContainsKey(TraitFactory.Traits.Small.ToString()))
        {
            return instantiatedTraits[TraitFactory.Traits.Small.ToString()];
        }
        SizeTrait small = new SizeTrait();
        small.size = (int)Size.Small;
        small.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 0);
        small.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 0);
        small.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        small.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);


        small.inheritanceChance = 0.5f;

        small.name = TraitFactory.Traits.Small.ToString();
        small.type = TraitFactory.Traits.Small.ToString();
        small.traitClass = TraitFactory.TraitClass.Size.ToString();

        small.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), -1.0f);
        small.linkageMap.Add(TraitFactory.Traits.Weak.ToString(), 1.0f);
		small.linkageMap.Add(TraitFactory.Traits.Slow.ToString(), -1.0f);
		small.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 1.0f);

        small.linkageMap.Add(Size.Tiny.ToString(), 0.5f);
        small.linkageMap.Add(Size.Small.ToString(), 1.5f);
        small.linkageMap.Add(Size.Midsized.ToString(), 0.5f);


        instantiatedTraits[TraitFactory.Traits.Small.ToString()] = small;
        return small;
    }

    public static SizeTrait createMidsized()
    {
        if (instantiatedTraits.ContainsKey(TraitFactory.Traits.Midsized.ToString()))
        {
            return instantiatedTraits[TraitFactory.Traits.Midsized.ToString()];
        }
        SizeTrait midsized = new SizeTrait();
        midsized.size = (int)Size.Midsized;
        midsized.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        midsized.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 0);
        midsized.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        midsized.attributes.Add(TraitFactory.Attribute.Food.ToString(), 2);

        midsized.inheritanceChance = 0.5f;

        midsized.name = TraitFactory.Traits.Midsized.ToString();
        midsized.type = TraitFactory.Traits.Midsized.ToString();
        midsized.traitClass = TraitFactory.TraitClass.Size.ToString();

        midsized.linkageMap.Add(Size.Small.ToString(), 0.5f);
        midsized.linkageMap.Add(Size.Midsized.ToString(), 1.5f);
        midsized.linkageMap.Add(Size.Large.ToString(), 0.5f);

        instantiatedTraits[TraitFactory.Traits.Midsized.ToString()] = midsized;
        return midsized;
    }

    public static SizeTrait createLarge()
    {
        if (instantiatedTraits.ContainsKey(TraitFactory.Traits.Large.ToString()))
        {
            return instantiatedTraits[TraitFactory.Traits.Large.ToString()];
        }
        SizeTrait large = new SizeTrait();
        large.size = (int)Size.Large;
        large.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        large.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 1);
        large.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        large.attributes.Add(TraitFactory.Attribute.Food.ToString(), 3);

        large.inheritanceChance = 0.5f;

        large.name = TraitFactory.Traits.Large.ToString();
        large.type = TraitFactory.Traits.Large.ToString();
        large.traitClass = TraitFactory.TraitClass.Size.ToString();

		large.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), 1.0f);
		large.linkageMap.Add(TraitFactory.Traits.Weak.ToString(), -1.0f);
		large.linkageMap.Add(TraitFactory.Traits.Slow.ToString(), 1.0f);
		large.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), -1.0f);
		large.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), -1.0f);
		large.linkageMap.Add(TraitFactory.Traits.Climb.ToString(), -1.0f);


        large.linkageMap.Add(Size.Midsized.ToString(), 0.5f);
        large.linkageMap.Add(Size.Large.ToString(), 1.5f);
        large.linkageMap.Add(Size.Huge.ToString(), 0.5f);

        instantiatedTraits[TraitFactory.Traits.Large.ToString()] = large;
        return large;
    }

    public static SizeTrait createHuge()
    {
        if (instantiatedTraits.ContainsKey(TraitFactory.Traits.Huge.ToString()))
        {
            return instantiatedTraits[TraitFactory.Traits.Huge.ToString()];
        }
        SizeTrait huge = new SizeTrait();
        huge.size = (int)Size.Huge;
        huge.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 2);
        huge.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 2);
        huge.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        huge.attributes.Add(TraitFactory.Attribute.Food.ToString(), 4);

        huge.inheritanceChance = 0.5f;

        huge.name = TraitFactory.Traits.Huge.ToString();
        huge.type = TraitFactory.Traits.Huge.ToString();
        huge.traitClass = TraitFactory.TraitClass.Size.ToString();

        huge.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), 1.5f);
		huge.linkageMap.Add(TraitFactory.Traits.Weak.ToString(), -2.0f);
		huge.linkageMap.Add(TraitFactory.Traits.Slow.ToString(), 1.5f);
		huge.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), -2.0f);
		huge.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), -2.0f);
		huge.linkageMap.Add(TraitFactory.Traits.Climb.ToString(), -2.0f);


        huge.linkageMap.Add(Size.Large.ToString(), 0.5f);
        huge.linkageMap.Add(Size.Huge.ToString(), 1.5f);
        huge.linkageMap.Add(Size.Enormous.ToString(), 0.5f);

        instantiatedTraits[TraitFactory.Traits.Huge.ToString()] = huge;
        return huge;
    }

    public static SizeTrait createEnormous()
    {
        if (instantiatedTraits.ContainsKey(TraitFactory.Traits.Enormous.ToString()))
        {
            return instantiatedTraits[TraitFactory.Traits.Enormous.ToString()];
        }
        SizeTrait enormous = new SizeTrait();
        enormous.size = (int)Size.Enormous;
        enormous.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 3);
        enormous.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 3);
        enormous.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        enormous.attributes.Add(TraitFactory.Attribute.Food.ToString(), 6);

        enormous.inheritanceChance = 0.5f;

        enormous.name = TraitFactory.Traits.Enormous.ToString();
        enormous.type = TraitFactory.Traits.Enormous.ToString();
        enormous.traitClass = TraitFactory.TraitClass.Size.ToString();

        enormous.linkageMap.Add(TraitFactory.Traits.Strong.ToString(), 3.0f);
		enormous.linkageMap.Add(TraitFactory.Traits.Weak.ToString(), -3.0f);
		enormous.linkageMap.Add(TraitFactory.Traits.Slow.ToString(), 3.0f);
		enormous.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), -3.0f);
		enormous.linkageMap.Add(TraitFactory.Traits.Flying.ToString(), -6.0f);
		enormous.linkageMap.Add(TraitFactory.Traits.Climb.ToString(), -6.0f);




        enormous.linkageMap.Add(Size.Huge.ToString(), 0.5f);
        enormous.linkageMap.Add(Size.Enormous.ToString(), 1.5f);

        instantiatedTraits[TraitFactory.Traits.Enormous.ToString()] = enormous;
        return enormous;
    }
}
