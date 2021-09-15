namespace Converter.InterfaceType
{
    public interface IOneWayConverter<TType, TOtherType>
    {
        TOtherType Convert(TType data);
    }
}