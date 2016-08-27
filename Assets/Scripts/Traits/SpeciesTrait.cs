public class SpeciesTrait : SpecialTrait
{
    public int spriteIndex;

    public override bool isCompatible(BaseTrait other)
    {
        return this.type == other.type;
    }
}
