#nullable enable

namespace System
{
    partial struct Box<T>
    {
        public override string ToString()
            =>
            Value.ToStringOrEmpty();
    }
}
