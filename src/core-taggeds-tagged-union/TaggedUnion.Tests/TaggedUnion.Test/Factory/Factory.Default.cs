#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Taggeds.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void Default_ExpectIsFirstGetsFalse()
        {
            var taggedUnion = default(TaggedUnion<RefType?, StructType>);
            Assert.False(taggedUnion.IsFirst);
        }

        [Test]
        public void Default_ExpectIsSecondGetsFalse()
        {
            var taggedUnion = default(TaggedUnion<StructType?, RefType>);
            Assert.False(taggedUnion.IsSecond);
        }

        [Test]
        public void Default_ExpectIsInitializedGetsFalse()
        {
            var taggedUnion = default(TaggedUnion<RefType?, StructType?>);
            Assert.False(taggedUnion.IsInitialized);
        }
    }
}
