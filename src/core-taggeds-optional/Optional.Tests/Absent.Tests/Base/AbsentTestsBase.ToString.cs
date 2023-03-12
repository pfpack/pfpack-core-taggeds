using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void ToString_ExpectAbsentFormat()
    {
        var actual = default(Absent<T>).ToString();

        var expected = string.Format("Absent<{0}>:()", typeof(T).Name);

        Assert.AreEqual(expected, actual);
    }
}
