#nullable enable

namespace PrimeFuncPack.UnitTest.Data
{
    partial class DataGenerator
    {
        public static RefType GenerateRefType()
            =>
            new RefType
            {
                Id = GenerateInteger()
            };
    }
}
