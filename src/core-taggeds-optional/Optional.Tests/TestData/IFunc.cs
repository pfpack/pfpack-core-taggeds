using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Tests;

internal interface IFunc<TResult>
{
    TResult Invoke();

    Task<TResult> InvokeAsync();

    ValueTask<TResult> InvokeValueAsync();

    TResult Invoke<T>(T value);

    Task<TResult> InvokeAsync<T>(T value);

    ValueTask<TResult> InvokeValueAsync<T>(T value);
}