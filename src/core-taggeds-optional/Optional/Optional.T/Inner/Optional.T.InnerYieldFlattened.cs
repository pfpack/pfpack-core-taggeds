﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IEnumerable<T> InnerYieldFlattened()
    {
        if (hasValue)
        {
            yield return value;
        }
    }
}
