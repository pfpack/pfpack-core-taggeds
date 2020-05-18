#nullable enable

using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.Primitives
{
    partial class Box<T>
    {
        private static bool ValueEquals(in T valueA, in T valueB) => (valueA, valueB) switch
        {
            (var optionalA, var optionalB) when optionalA is null && optionalB is null
            =>
            true,

            (var optionalA, var optionalB) when optionalA is null || optionalB is null
            =>
            false,

            (var presentA, var presentB)
            =>
            EqualityComparer<T>.Default.Equals(presentA, presentB)
        };
    }
}
