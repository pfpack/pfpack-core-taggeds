#nullable enable

namespace PrimeFuncPack.UnitTest.Data
{
    partial class DataGenerator
    {
        public static decimal GenerateDecimal()
            => GenerateDecimal(min: decimal.MinValue, max: decimal.MaxValue);

        public static decimal GenerateDecimal(in decimal min)
            => GenerateDecimal(min: min, max: decimal.MaxValue);

        public static decimal GenerateDecimal(in decimal min, in decimal max)
            =>
            (max >= min) switch
            {
                true
                => CalcualteDecimal(value: Faker.Random.Decimal(), min: min, max: max),
                _
                => throw CreateMaxMustBeGreaterThenMinException(nameof(max))
            };

        private static decimal CalcualteDecimal(
            in decimal value, in decimal min, in decimal max)
        {
            checked
            {
                return value * max + (1 - value) * min;
            }
        }
    }
}
