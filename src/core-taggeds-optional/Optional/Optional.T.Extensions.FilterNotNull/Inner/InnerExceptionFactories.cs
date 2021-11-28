namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        private static InvalidOperationException InnerCreateExpectedNotNullOrAbsentException()
            =>
            new("The optional is expected to have a not null value or to be absent.");

        private static InvalidOperationException InnerCreateUnexpectedNullException_MustNeverBeInvoked()
            =>
            new("The optional has unexpected null value.");
    }
}
