#nullable enable

using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests
{
    public sealed partial class UnitExtensionsInvokeTests
    {
        private const int MinusTwentyOne = -21;

        private const double PlusTwentyOnePointSeventyFive = 21.75;

        private const decimal PlusOneHundredPointFive = 100.5m;

        private const decimal MinusSeventyOnePointThree = -71.3m;

        private const string SomeOtherText = "Some Other Text";

        private static DateTime Year2017March25H19Min31 { get; } = new DateTime(2017, 3, 25, 19, 31, 00);

        private static StructType OtherTextStructType { get; } = new StructType { Text = "Other text" };
    }
}
