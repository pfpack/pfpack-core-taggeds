#nullable enable

namespace System.Linq
{
    partial class DictionariesExtensions
    {
        private static InvalidOperationException CreateMoreThanOneMatchException()
            =>
            new("The pairs contains more than one key equal to the specified.");
    }
}
