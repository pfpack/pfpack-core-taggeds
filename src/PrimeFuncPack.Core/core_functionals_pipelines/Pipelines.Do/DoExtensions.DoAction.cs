#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial class DoExtensions
    {
        public static T DoAction<T>(this T value, in Func<T, Unit> func)
            =>
            value.ImplDo(func);

        public static T DoAction<T>(this T value, in Action<T> action)
            =>
            value.ImplDo(action.InvokeToUnit);

        public static Task<Unit> DoActionAsync<T>(this T value, in Func<T, Task<Unit>> funcAsync)
            =>
            value.ImplDo(funcAsync);

        public static Task DoActionAsync<T>(this T value, in Func<T, Task> funcAsync)
            =>
            value.ImplDo(funcAsync);

        public static ValueTask<Unit> DoActionAsync<T>(this T value, in Func<T, ValueTask<Unit>> funcAsync)
            =>
            value.ImplDo(funcAsync);

        public static ValueTask DoActionAsync<T>(this T value, in Func<T, ValueTask> funcAsync)
            =>
            value.ImplDo(funcAsync);
    }
}
