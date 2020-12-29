#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    partial class StringsTests
    {
        [Test]
        public void Empty_ExpectEmptyString()
        {
            var actual = Strings.Empty;
            Assert.IsEmpty(actual);
        }

        [Test]
        public void GetEmpty_ExpectEmptyString()
        {
            var actual = Strings.GetEmpty();
            Assert.IsEmpty(actual);
        }
    }
}
