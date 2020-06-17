#nullable enable

namespace System.Linq
{
    partial class DictionariesExtensions
    {
        private static Func<Exception> GetMoreThanOneMatchExceptionFactory()
            =>
            () => new InvalidOperationException("The dictionary contains more than one key equal to the specified.");
    }
}
