#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    partial class PipelineTests
    {
        [Test]
        [TestCaseSource(nameof(ValueTestSource))]
        public void Pipe_ExpectSourceValue(
            object? sourceValue)
        {
            var actual = Pipeline.Pipe(sourceValue);
            Assert.AreSame(sourceValue, actual);
        }
    }
}
