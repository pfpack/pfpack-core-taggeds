namespace System
{
    partial class Optional
    {
        private static ArgumentException CreateExpectedSpecifiedException(string paramName)
            =>
            new(message: "The value is expected to be specified.", paramName: paramName);
    }
}
