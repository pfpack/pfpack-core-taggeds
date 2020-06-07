#nullable enable

namespace PrimeFuncPack
{
    public interface IResult<TValue, TError>
        where TError : notnull
    {
        bool IsSuccess { get; }

        bool IsFailure { get; }
    }
}
