#nullable enable

namespace System.Linq
{
    partial class OptionalLinqDictionariesExtensions
    {
        private static InvalidOperationException CreateMoreThanOneMatchException()
            =>
            new("The pairs contain more than one key equal to the specified.");
    }
}
