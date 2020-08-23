#nullable enable

namespace PrimeFuncPack.UnitTest.Data
{
    partial class DataGenerator
    {
        public static string GenerateUrl()
            => Faker.Internet.Url();

        public static string GenerateEmail()
            => Faker.Internet.Email();
    }
}
