using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentStaticTestsBase<T>
{
    [Test]
    public void Equality_Equals_OfAndDefault_ExpectTrue()
    {
        var actual = Absent.Equals(Absent.Of<T>(), default(Absent<T>));
        Assert.True(actual);
    }

    [Test]
    public void Equality_Equals_OfAndNew_ExpectTrue()
    {
        var actual = Absent.Equals(Absent.Of<T>(), new Absent<T>());
        Assert.True(actual);
    }
}
