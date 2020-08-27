#nullable enable

using NUnit.Framework;
using PrimeFuncPack.Core.Infrastructure.Tests.Stubs;
using System;

namespace PrimeFuncPack.Core.Infrastructure.Tests
{
    partial class BoxTests
    {
        [Test]
        [TestCaseSource(nameof(RefTypeTestSource))]
        public void Implicit_ExpectResultIsSameAsBoxValue(
            in RefType? source)
        {
            var box = new Box<RefType?>(source);

            RefType? actual = box;
            var expected = box.Value;

            Assert.AreEqual(expected, actual);
        }
    }
}
