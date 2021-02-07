#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial class InvokeThenToUnitAsyncExtensions
    {
        public static Task<Unit> InvokeThenToUnitAsync(this Func<Task> funcAsync)
            =>
            Unit.InvokeAsync(funcAsync);

        public static Task<Unit> InvokeThenToUnitAsync<T>(this Func<T, Task> funcAsync, T obj)
            =>
            Unit.InvokeAsync(funcAsync, obj);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2>(
            this Func<T1, T2, Task> funcAsync,
            T1 arg1,
            T2 arg2)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3>(
            this Func<T1, T2, T3, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5>(
            this Func<T1, T2, T3, T4, T5, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6>(
            this Func<T1, T2, T3, T4, T5, T6, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7>(
            this Func<T1, T2, T3, T4, T5, T6, T7, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8,
            T9 arg9)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8,
            T9 arg9,
            T10 arg10)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9,
                arg10);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8,
            T9 arg9,
            T10 arg10,
            T11 arg11)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9,
                arg10,
                arg11);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8,
            T9 arg9,
            T10 arg10,
            T11 arg11,
            T12 arg12)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9,
                arg10,
                arg11,
                arg12);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8,
            T9 arg9,
            T10 arg10,
            T11 arg11,
            T12 arg12,
            T13 arg13)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9,
                arg10,
                arg11,
                arg12,
                arg13);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8,
            T9 arg9,
            T10 arg10,
            T11 arg11,
            T12 arg12,
            T13 arg13,
            T14 arg14)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9,
                arg10,
                arg11,
                arg12,
                arg13,
                arg14);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8,
            T9 arg9,
            T10 arg10,
            T11 arg11,
            T12 arg12,
            T13 arg13,
            T14 arg14,
            T15 arg15)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9,
                arg10,
                arg11,
                arg12,
                arg13,
                arg14,
                arg15);

        public static Task<Unit> InvokeThenToUnitAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8,
            T9 arg9,
            T10 arg10,
            T11 arg11,
            T12 arg12,
            T13 arg13,
            T14 arg14,
            T15 arg15,
            T16 arg16)
            =>
            Unit.InvokeAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9,
                arg10,
                arg11,
                arg12,
                arg13,
                arg14,
                arg15,
                arg16);
    }
}
