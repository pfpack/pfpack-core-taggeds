#nullable enable

namespace PrimeFuncPack.UnitTest
{
    partial class TestData
    {
        public static StructType SomeTextStructType { get; } = new StructType { Text = SomeString };

        public static StructType NullTextStructType { get; } = new StructType();
    }
}
