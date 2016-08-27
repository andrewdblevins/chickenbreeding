using System.Collections.Generic;

public class SpeciesFactory {
    static Dictionary<string, SpeciesTrait> instantiatedTraits = new Dictionary<string, SpeciesTrait>();

    /** This should only be referenced by data classes. */
    public enum Species
    {
        Wolf,
        Rabbit,
        Chicken,
    }

    private static string SPECIES = "species";

    public static SpeciesTrait createWolf()
    {
        if (instantiatedTraits.ContainsKey(Species.Wolf.ToString()))
        {
            return instantiatedTraits[Species.Wolf.ToString()];
        }
        SpeciesTrait wolf = new SpeciesTrait();
        wolf.spriteIndex = 5;
        wolf.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), 1);
        wolf.attributes.Add(TraitFactory.Attribute.Strength.ToString(), 1);
        wolf.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 2);
        wolf.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        wolf.inheritanceChance = 1f;

        wolf.name = Species.Wolf.ToString();
        wolf.type = Species.Wolf.ToString();
        wolf.traitClass = SPECIES;

        wolf.linkageMap.Add(TraitFactory.Traits.Midsized.ToString(), 0.3f);
        wolf.linkageMap.Add(TraitFactory.Traits.Slow.ToString(), 0.2f);
        wolf.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 0.1f);

        instantiatedTraits[Species.Wolf.ToString()] = wolf;
        return wolf;
    }

    public static SpeciesTrait createRabbit()
    {
        if (instantiatedTraits.ContainsKey(Species.Rabbit.ToString()))
        {
            return instantiatedTraits[Species.Rabbit.ToString()];
        }
        SpeciesTrait rabbit = new SpeciesTrait();
        rabbit.spriteIndex = 45;
        rabbit.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), -1);
        rabbit.attributes.Add(TraitFactory.Attribute.Strength.ToString(), -1);
        rabbit.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        rabbit.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        rabbit.inheritanceChance = 1f;

        rabbit.name = Species.Rabbit.ToString();
        rabbit.type = Species.Rabbit.ToString();
        rabbit.traitClass = SPECIES;

        rabbit.linkageMap.Add(TraitFactory.Traits.Quick.ToString(), 0.3f);
        rabbit.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 0.6f);

        instantiatedTraits[Species.Rabbit.ToString()] = rabbit;
        return rabbit;
    }

    public static SpeciesTrait createChicken()
    {
        if (instantiatedTraits.ContainsKey(Species.Chicken.ToString()))
        {
            return instantiatedTraits[Species.Chicken.ToString()];
        }
        SpeciesTrait chicken = new SpeciesTrait();
        chicken.spriteIndex = 35;
        chicken.attributes.Add(TraitFactory.Attribute.Fighting.ToString(), -1);
        chicken.attributes.Add(TraitFactory.Attribute.Strength.ToString(), -1);
        chicken.attributes.Add(TraitFactory.Attribute.Tracking.ToString(), 0);
        chicken.attributes.Add(TraitFactory.Attribute.Food.ToString(), 1);

        chicken.inheritanceChance = 1f;

        chicken.name = Species.Chicken.ToString();
        chicken.type = Species.Chicken.ToString();
        chicken.traitClass = SPECIES;

        chicken.linkageMap.Add(TraitFactory.Traits.Tiny.ToString(), 0.6f);

        instantiatedTraits[Species.Rabbit.ToString()] = chicken;
        return chicken;
    }
}
