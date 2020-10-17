#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public async Task ThisValueAsync_SourceIsDefault_ExpectSourceValue()
        {
            var source = default(TaggedUnion<StructType, RefType>);
            var actual = await source.ThisValueAsync();

            Assert.AreEqual(source, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public async Task ThisValueAsync_SourceIsFirst_ExpectSourceValue(
            object? sourceValue)
        {
            var source = TaggedUnion<object?, RefType>.First(sourceValue);
            var actual = await source.ThisValueAsync();

            Assert.AreEqual(source, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public async Task ThisValueAsync_SourceIsSecond_ExpectSourceValue(
            object? sourceValue)
        {
            var source = TaggedUnion<StructType?, object?>.Second(sourceValue);
            var actual = await source.ThisValueAsync();

            Assert.AreEqual(source, actual);
        }
    }
}
