#nullable enable

using PrimeFuncPack.Extensions.Primitives;
using System;

namespace PrimeFuncPack
{
    public readonly partial struct Optional<T> : IEquatable<Optional<T>>, ISamenessPossessor<Optional<T>>
    {
        public static readonly Optional<T> Absent;

        private readonly Box<T>? box;

        public bool IsPresent => box is object;

        public bool IsAbsent => box is null;

        public T Value => box ?? throw CreateAbsentException();

        public Optional(in T value)
            =>
            box = value switch { null => null, var present => present };

        public static implicit operator Optional<T>(in T value)
            =>
            new Optional<T>(value);

        public static implicit operator T(in Optional<T> optional)
            =>
            optional.Value;

        public override string? ToString()
            =>
            box switch { object present => present.ToString(), _ => string.Empty };

        private static Exception CreateAbsentException()
            =>
            new InvalidOperationException("The optional does not have a value.");
    }
}
