﻿#nullable enable

namespace System
{
    partial struct Box<T>
    {
        public static implicit operator T(Box<T> box)
            =>
            box.Value;
    }
}
