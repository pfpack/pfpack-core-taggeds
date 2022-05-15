﻿using System.Collections.Generic;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    private static Type EqualityContract
        =>
        typeof(TaggedUnion<TFirst, TSecond>);

    private static EqualityComparer<Type> EqualityContractComparer
        =>
        EqualityComparer<Type>.Default;

    private static EqualityComparer<TFirst> FirstComparer
        =>
        EqualityComparer<TFirst>.Default;

    private static EqualityComparer<TSecond> SecondComparer
        =>
        EqualityComparer<TSecond>.Default;
}
