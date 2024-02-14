using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentStaticTestsBase<T>
{
    [Test]
    public void Equality_Equals_OfAndDefault_ExpectTrue()
    {
        var actual = Absent.Equals(Absent.Of<T>(), default(Absent<T>));
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Equality_Equals_OfAndNew_ExpectTrue()
    {
        var actual = Absent.Equals(Absent.Of<T>(), new Absent<T>());
        Assert.That(actual, Is.True);
    }
}
