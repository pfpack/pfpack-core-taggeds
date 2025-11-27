using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string InnerToString()
    {
        if (hasValue)
        {
            if (value is not null)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    OptionalToStringCompositeFormat.PresentValue,
                    typeof(T).Name,
                    value);
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                OptionalToStringCompositeFormat.PresentNull,
                typeof(T).Name);
        }

        return string.Format(
            CultureInfo.InvariantCulture,
            OptionalToStringCompositeFormat.Absent,
            typeof(T).Name);
    }
}

internal static class OptionalToStringCompositeFormat
{
    internal static CompositeFormat PresentValue => Instance.PresentValue;

    internal static CompositeFormat PresentNull => Instance.PresentNull;

    internal static CompositeFormat Absent => Instance.Absent;

    private static class Instance
    {
        internal static readonly CompositeFormat PresentValue = CompositeFormat.Parse(
            "Optional<{0}>:Present:\"{1}\"");

        internal static readonly CompositeFormat PresentNull = CompositeFormat.Parse(
            "Optional<{0}>:Present:null");

        internal static readonly CompositeFormat Absent = CompositeFormat.Parse(
            "Optional<{0}>:Absent:()");
    }
}
