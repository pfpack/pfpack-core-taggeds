#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public static explicit operator T(Present<T> present)
            =>
            present.value;
    }
}
