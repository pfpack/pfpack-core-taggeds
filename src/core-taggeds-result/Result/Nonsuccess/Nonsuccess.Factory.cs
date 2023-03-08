namespace System.Success;

partial class Nonsuccess
{
    public static Nonsuccess<TFailure> Of<TFailure>(TFailure failure)
        where TFailure : struct
        =>
        new(failure);
}
