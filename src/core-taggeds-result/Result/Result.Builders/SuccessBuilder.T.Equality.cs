#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core
{
    partial struct SuccessBuilder<TSuccess>
    {
        public bool Equals(SuccessBuilder<TSuccess> other)
            =>
            SuccessEquality.Equals(success, other.success);

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
            SuccessHashCodeOrDefault());

        private int SuccessHashCodeOrDefault() => success switch
        {
            not null => SuccessEquality.GetHashCode(success),
            _ => default
        };

        private static IEqualityComparer<TSuccess> SuccessEquality => EqualityComparer<TSuccess>.Default;
    }
}
