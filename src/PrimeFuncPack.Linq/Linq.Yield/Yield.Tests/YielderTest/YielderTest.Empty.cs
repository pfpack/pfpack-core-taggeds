#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System.Linq;

namespace PrimeFuncPack.Linq.Yield.Tests
{
    partial class YielderTest
    {
        [Test]
        public void YieldEmpty_ExpectEmptyCollection()
        {
            var actual = Yielder.YieldEmpty<StructType?>();
            Assert.IsEmpty(actual);
        }
    }
}
