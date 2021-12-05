namespace System.Linq;

partial class OptionalLinqExtensions
{
    private const string InnerTryGetValueOrAbsentObsoleteMessage
        =
        $"This method is not intended for use. Call {InnerGetValueOrAbsentActual} instead.";

    private const string InnerGetValueOrAbsentActual
        =
        nameof(GetValueOrAbsent);
}
