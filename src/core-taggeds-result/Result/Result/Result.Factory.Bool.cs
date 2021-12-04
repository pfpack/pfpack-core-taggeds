namespace System
{
    partial class Result
    {
        public static Result<Unit, Unit> True()
            =>
            new(success: default);

        public static Result<Unit, Unit> False()
            =>
            new(failure: default);
    }
}
