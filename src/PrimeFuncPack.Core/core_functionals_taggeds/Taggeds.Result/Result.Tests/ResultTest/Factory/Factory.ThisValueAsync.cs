#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class ResultTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ResultTestSource))]
        public async Task ThisValueAsync_ExpectSourceValue(
            Result<RefType, StructType> source)
        {
            var actual = await source.ThisValueAsync();
            Assert.AreEqual(source, actual);
        }
    }
}