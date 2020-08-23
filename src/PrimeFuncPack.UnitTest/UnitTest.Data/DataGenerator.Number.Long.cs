#nullable enable

namespace PrimeFuncPack.UnitTest.Data
{
    partial class DataGenerator
    {
        public static long GenerateLong()
            => Faker.Random.Long();

        public static long GenerateLong(in long min)
            => Faker.Random.Long(min: min);

        public static long GenerateLong(in long min, in long max)
            =>
            (max >= min) switch
            {
                true
                => Faker.Random.Long(min: min, max: max),
                _
                => throw CreateMaxMustBeGreaterThenMinException(nameof(max))
            };
    }
}
