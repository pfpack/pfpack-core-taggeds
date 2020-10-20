#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public async Task ThisAsync_SourceIsDefault_ExpectSourceValue()
        {
            var source = default(TaggedUnion<RefType, StructType>);
            var actual = await source.ThisAsync();

            Assert.AreEqual(source, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public async Task ThisAsync_SourceIsFirst_ExpectSourceValue(
            object? sourceValue)
        {
            var source = TaggedUnion<object?, StructType>.First(sourceValue);
            var actual = await source.ThisAsync();

            Assert.AreEqual(source, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public async Task ThisAsync_SourceIsSecond_ExpectSourceValue(
            object? sourceValue)
        {
            var source = TaggedUnion<RefType, object?>.Second(sourceValue);
            var actual = await source.ThisAsync();

            Assert.AreEqual(source, actual);
        }
    }
}
