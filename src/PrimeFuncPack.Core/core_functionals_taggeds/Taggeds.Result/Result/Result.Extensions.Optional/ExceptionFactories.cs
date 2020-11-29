#nullable enable

namespace System
{
    partial class OptionalResultExtensions
    {
        private static ArgumentException CreateSuccessNullException(in string paramName)
            =>
            new(message: "Success must be not null.", paramName: paramName);
    }
}
