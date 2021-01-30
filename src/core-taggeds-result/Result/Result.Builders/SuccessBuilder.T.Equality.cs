#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core
{
    partial struct SuccessBuilder<TSuccess>
    {
        public bool Equals(SuccessBuilder<TSuccess> other)
            =>
            EqualityComparer.Equals(success, other.success);

        public static bool operator ==(SuccessBuilder<TSuccess> left, SuccessBuilder<TSuccess> right)
            =>
            left.Equals(right);

        public static bool operator !=(SuccessBuilder<TSuccess> left, SuccessBuilder<TSuccess> right)
            =>
            left.Equals(right) is false;

        public override bool Equals(object? obj)
            =>
            obj is SuccessBuilder<TSuccess> other &&
            Equals(other);

        public override int GetHashCode() => HashCode.Combine(
            typeof(SuccessBuilder<TSuccess>),
            HashCodeOrDefault());

        private int HashCodeOrDefault() => success switch
        {
            not null => EqualityComparer.GetHashCode(success),
            _ => default
        };

        private static IEqualityComparer<TSuccess> EqualityComparer => EqualityComparer<TSuccess>.Default;
    }
}
