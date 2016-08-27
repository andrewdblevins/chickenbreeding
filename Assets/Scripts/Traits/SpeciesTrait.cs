public class SpeciesTrait : SpecialTrait
{
    public override bool isCompatible(BaseTrait other)
    {
        return this.type == other.type;
    }
}
