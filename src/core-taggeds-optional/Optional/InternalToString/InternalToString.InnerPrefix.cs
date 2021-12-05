namespace System;

partial class InternalToString<T>
{
    private static class InnerPrefix
    {
        public const string Present = InnerPresent;

        public const string Absent = InnerAbsent;

        public const string OptionalPresent = $"{InnerOptional}.{InnerPresent}";

        public const string OptionalAbsent = $"{InnerOptional}.{InnerAbsent}";

        private const string InnerPresent = "Present";

        private const string InnerAbsent = "Absent";

        private const string InnerOptional = "Optional";
    }
}
