using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace PrimeFuncPack.Core.Tests;

internal interface IAction
{
    void Invoke()
    {
    }

    Task InvokeAsync()
        =>
        Task.CompletedTask;

    ValueTask InvokeValueAsync()
        =>
        ValueTask.CompletedTask;

    void Invoke<T>(T value)
    {
    }

    Task InvokeAsync<T>(T value)
        =>
        Task.CompletedTask;

    ValueTask InvokeValueAsync<T>(T value)
        =>
        ValueTask.CompletedTask;
}