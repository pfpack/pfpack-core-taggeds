﻿using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Obsolete]
    [Test]
    public void Default_ExpectIsInitializedGetsFalse()
    {
        var taggedUnion = default(TaggedUnion<RefType?, StructType?>);
        Assert.False(taggedUnion.IsInitialized);
    }
}
