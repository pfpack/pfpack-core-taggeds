#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core
{
    partial struct FailureBuilder<TFailure>
    {
        public bool Equals(FailureBuilder<TFailure> other)
            =>
            Equality.Equals(failure, other.failure);

        public static bool operator ==(FailureBuilder<TFailure> left, FailureBuilder<TFailure> right)
            =>
            left.Equals(right);

        public static bool operator !=(FailureBuilder<TFailure> left, FailureBuilder<TFailure> right)
            =>
            left.Equals(right) is false;

        public override bool Equals(object? obj)
            =>
            obj is FailureBuilder<TFailure> other &&
            Equals(other);

        public override int GetHashCode() => HashCode.Combine(
            typeof(FailureBuilder<TFailure>),
            Equality.GetHashCode(failure));

        private static IEqualityComparer<TFailure> Equality => EqualityComparer<TFailure>.Default;
    }
}
