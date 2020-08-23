#nullable enable

namespace PrimeFuncPack.UnitTest.Data
{
    partial class DataGenerator
    {
        public static int GenerateInteger()
            => Faker.Random.Int();

        public static int GenerateInteger(in int min)
            => Faker.Random.Int(min: min);

        public static int GenerateInteger(in int min, in int max)
            =>
            (max >= min) switch
            {
                true
                => Faker.Random.Int(min: min, max: max),
                _
                => throw CreateMaxMustBeGreaterThenMinException(nameof(max))
            };
    }
}
