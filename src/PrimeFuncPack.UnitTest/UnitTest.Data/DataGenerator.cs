#nullable enable

using Bogus;
using System;

namespace PrimeFuncPack.UnitTest.Data
{
    public static partial class DataGenerator
    {
        static DataGenerator()
            => Faker = new Faker();

        private static Faker Faker { get; }

        public static ArgumentOutOfRangeException CreateMaxMustBeGreaterThenMinException(in string paramName)
            => new ArgumentOutOfRangeException(paramName: paramName, message: "Max must be greater than min.");
    }
}
