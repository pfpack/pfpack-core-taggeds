namespace System.Linq;

partial class OptionalLinqDictionariesExtensions
{
    private static InvalidOperationException InnerCreateMoreThanOneMatchException()
        =>
        new("The pairs contain more than one key equal to the specified.");
}
