﻿namespace Converter.InterfaceType
{
    public interface IOneWayConverter<in TType, out TOtherType>
    {
        TOtherType Convert(TType data);
    }
}