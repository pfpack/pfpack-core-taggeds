#nullable enable

using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests
{
    public sealed partial class UnitExtensionsInvoketValueAsyncTests
    {
        private const int MinusFortyFive = -45;

        private const double PlusFortyOnePointSeventyFive = 41.75;

        private const decimal PlusTwoHundredPointFive = 200.5m;

        private const decimal MinusSeventyFivePointSeven = -75.7m;

        private const string CustomText = "Custom Text";

        private static DateTime Year2015March11H01Min15 { get; } = new DateTime(2015, 3, 11, 01, 15, 00);

        private static StructType CustomStringStructType { get; } = new StructType { Text = "Custom String" };
    }
}
