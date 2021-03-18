#nullable enable

namespace System
{
    partial class Optional
    {
        private static ArgumentException CreateExpectedNotNullValueException(string paramName)
            =>
            new(message: "The value is expected to be not null.", paramName: paramName);
    }
}
