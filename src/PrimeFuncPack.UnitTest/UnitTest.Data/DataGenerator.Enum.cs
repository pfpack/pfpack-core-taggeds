#nullable enable

using System;

namespace PrimeFuncPack.UnitTest.Data
{
    partial class DataGenerator
    {
        public static TEnum GenerateEnum<TEnum>()
            where TEnum : struct, Enum
            =>
            Faker.Random.Enum<TEnum>();
    }
}
