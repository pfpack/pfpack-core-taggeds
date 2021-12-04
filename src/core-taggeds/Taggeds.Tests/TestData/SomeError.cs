using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests
{
    internal readonly struct SomeError
    {
        private readonly int errorCode;
        
        public SomeError(int errorCode)
            =>
            this.errorCode = errorCode;

        public bool Equals(SomeError other)
            =>
            ErrorCodeEquality.Equals(errorCode, other.errorCode);

        public static bool operator ==(SomeError left, SomeError right)
            =>
            left.Equals(right);

        public static bool operator !=(SomeError left, SomeError right)
            =>
            left.Equals(right) is false;

        public override bool Equals(object? obj)
            =>
            obj is SomeError other && Equals(other);

        public override int GetHashCode()
            =>
            HashCode.Combine(
                typeof(SomeError),
                ErrorCodeEquality.GetHashCode(errorCode));

        private static IEqualityComparer<int> ErrorCodeEquality
            =>
            EqualityComparer<int>.Default;
    }
}
