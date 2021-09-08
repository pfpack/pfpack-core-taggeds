#nullable enable

using NUnit.Framework;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitTests
    {
        [Test]
        public void ToString_ExpectUnitValueString()
        {
            var source = default(Unit);
            var actual = source.ToString();

            const string expected = "Unit:()";
            Assert.AreEqual(expected, actual);
        }
    }
}
