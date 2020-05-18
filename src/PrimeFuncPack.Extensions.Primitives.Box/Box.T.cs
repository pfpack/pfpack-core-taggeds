#nullable enable

using System;

namespace PrimeFuncPack.Extensions.Primitives
{
    public sealed partial class Box<T> : IEquatable<Box<T>>, ISamenessPossessor<Box<T>>
    {
        public T Value { get; }

        public Box(in T value)
            =>
            Value = value;

        public static implicit operator Box<T>(in T value)
            =>
            new Box<T>(value);

        public static implicit operator T(in Box<T> box)
            =>
            box.Value;

        public override string? ToString()
            =>
            Value switch { null => string.Empty, var present => present.ToString() };
    }
}
