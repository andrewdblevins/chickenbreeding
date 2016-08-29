using System.Collections.Generic;

public class AnimalDef {

    private SpeciesTrait speciesTrait;
    private SizeTrait sizeTrait;
    private List<BaseTrait> traits = new List<BaseTrait>();

    public SpeciesTrait SpeciesTrait
    {
        get
        {
            return speciesTrait;
        }

        set
        {
            speciesTrait = value;
        }
    }

    public SizeTrait SizeTrait
    {
        get
        {
            return sizeTrait;
        }

        set
        {
            sizeTrait = value;
        }
    }

    public List<BaseTrait> Traits
    {
        get
        {
            return traits;
        }

        set
        {
            traits = value;
        }
    }

    public int GetAttributeScore(string attribute)
    {
        int score = 3;

        score += SpeciesTrait.getAttributes(attribute);
        score += SizeTrait.getAttributes(attribute);

        foreach (BaseTrait t in Traits)
        {
            score += t.getAttributes(attribute);
        }

        return score;
    }
}
