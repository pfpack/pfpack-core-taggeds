#nullable enable

using System;

namespace PrimeFuncPack
{
    public readonly partial struct Unit : IEquatable<Unit>
    {
        public static readonly Unit Value;

        public override string ToString() => string.Empty;
    }
}
