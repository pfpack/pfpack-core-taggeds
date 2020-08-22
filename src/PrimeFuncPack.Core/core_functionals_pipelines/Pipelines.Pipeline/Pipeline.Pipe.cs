#nullable enable

namespace System
{
    partial class Pipeline
    {
        public static T Pipe<T>(T value) => value;
    }
}
