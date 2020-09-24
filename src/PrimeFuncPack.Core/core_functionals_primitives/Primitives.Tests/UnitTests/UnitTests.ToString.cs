#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitTests
    {
        [Test]
        public void ToString_ExpectEmptyString()
        {
            var source = default(Unit);
            var actual = source.ToString();

            Assert.IsEmpty(actual);
        }
    }
}
