namespace Converter.InterfaceType
{
    public interface ITwoWayConverter<TType, TOtherType>
    {
        TOtherType Convert(TType data);

        TType Convert(TOtherType data);
    }
}