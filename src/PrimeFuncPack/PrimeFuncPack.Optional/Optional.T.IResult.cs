#nullable enable

namespace PrimeFuncPack
{
    partial struct Optional<T>
    {
        bool IResult<T, Unit>.IsSuccess => IsPresent;

        bool IResult<T, Unit>.IsFailure => IsAbsent;
    }
}
