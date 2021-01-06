#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitTests
    {
        [Test]
        public void Value_ExpectDefault()
            =>
            Assert.AreEqual(Unit.Value, default(Unit));

        [Test]
        public void Get_ExpectDefault()
            =>
            Assert.AreEqual(Unit.Get(), default(Unit));

        [Test]
        public void Value_Get_ExpectAreEqual()
            =>
            Assert.AreEqual(Unit.Value, Unit.Get());
    }
}
