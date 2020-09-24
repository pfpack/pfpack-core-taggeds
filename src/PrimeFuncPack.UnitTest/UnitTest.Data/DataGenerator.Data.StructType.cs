
#nullable enable

namespace PrimeFuncPack.UnitTest.Data
{
    partial class DataGenerator
    {
        public static StructType GenerateStructType()
            =>
            new StructType
            {
                Text = GenerateText(5, 25)
            };
    }
}
