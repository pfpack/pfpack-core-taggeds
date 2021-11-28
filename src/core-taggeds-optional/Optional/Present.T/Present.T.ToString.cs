namespace System
{
    partial struct Present<T>
    {
        public override string ToString()
            =>
            InternalToString<T>.Present(value);
    }
}
