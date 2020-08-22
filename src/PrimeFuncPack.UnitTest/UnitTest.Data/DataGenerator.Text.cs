#nullable enable

namespace PrimeFuncPack.UnitTest.Data
{
    partial class DataGenerator
    {
        public const string Empty = "";

        public static string GenerateText()
            => GenerateText(minLength: 7, maxLength: 21);

        public static string GenerateText(in byte length)
            => Faker.Random.String2(length);

        public static string GenerateText(in byte minLength, in byte maxLength)
            =>
            (maxLength >= minLength) switch
            {
                true
                => Faker.Random.String2(minLength: minLength, maxLength: maxLength),
                _
                => throw CreateMaxMustBeGreaterThenMinException(nameof(maxLength))
            };
    }
}
