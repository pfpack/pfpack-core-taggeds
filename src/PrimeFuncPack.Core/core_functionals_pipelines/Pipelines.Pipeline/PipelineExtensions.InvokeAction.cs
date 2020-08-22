#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial class PipelineExtensions
    {
        public static T InvokeAction<T>(this T value, Func<T, Unit> func)
            =>
            value.ImplInvoke(func);

        public static T InvokeAction<T>(this T value, Action<T> action)
            =>
            value.ImplInvoke(action.InvokeThenToUnit);

        public static Task<Unit> InvokeActionAsync<T>(this T value, Func<T, Task<Unit>> funcAsync)
            =>
            value.ImplInvoke(funcAsync);

        public static Task InvokeActionAsync<T>(this T value, Func<T, Task> funcAsync)
            =>
            value.ImplInvoke(funcAsync);

        public static ValueTask<Unit> InvokeActionAsync<T>(this T value, Func<T, ValueTask<Unit>> funcAsync)
            =>
            value.ImplInvoke(funcAsync);

        public static ValueTask InvokeActionAsync<T>(this T value, Func<T, ValueTask> funcAsync)
            =>
            value.ImplInvoke(funcAsync);
    }
}
