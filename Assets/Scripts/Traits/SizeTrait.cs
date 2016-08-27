

public class SizeTrait : SpecialTrait
{
    public int size;

    public override bool isCompatible(BaseTrait other)
    {
        if (other is SizeTrait)
        {
            SizeTrait otherSize = other as SizeTrait;
            return 1 >= System.Math.Abs(otherSize.size - size);
        }
        return false;
    }
}
