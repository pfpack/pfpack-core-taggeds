#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial class UnitExtensions
    {
        public static ValueTask<Unit> InvokeThenToUnitValueAsync(this Func<ValueTask> funcAsync)
            =>
            Unit.InvokeValueAsync(funcAsync);

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T>(this Func<T, ValueTask> funcAsync, T obj)
            =>
            Unit.InvokeValueAsync(funcAsync, obj);

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2>(
            this Func<T1, T2, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2)
            =>
            Unit.InvokeValueAsync(
                funcAsync,
                arg1,
                arg2);

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3>(
            this Func<T1, T2, T3, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3)
            =>
            Unit.InvokeValueAsync(
                funcAsync,
                arg1,
                arg2,
                arg3);

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4)
            =>
            Unit.InvokeValueAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4);

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5>(
            this Func<T1, T2, T3, T4, T5, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5)
            =>
            Unit.InvokeValueAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5);

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6>(
            this Func<T1, T2, T3, T4, T5, T6, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6)
            =>
            Unit.InvokeValueAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6);

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7>(
            this Func<T1, T2, T3, T4, T5, T6, T7, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7)
            =>
            Unit.InvokeValueAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7);

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8)
            =>
            Unit.InvokeValueAsync(
                funcAsync,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8);

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask> funcAsync,
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
            Unit.InvokeValueAsync(
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

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, ValueTask> funcAsync,
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
            Unit.InvokeValueAsync(
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

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, ValueTask> funcAsync,
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
            Unit.InvokeValueAsync(
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

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, ValueTask> funcAsync,
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
            Unit.InvokeValueAsync(
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

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, ValueTask> funcAsync,
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
            Unit.InvokeValueAsync(
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

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, ValueTask> funcAsync,
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
            Unit.InvokeValueAsync(
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

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, ValueTask> funcAsync,
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
            Unit.InvokeValueAsync(
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

        public static ValueTask<Unit> InvokeThenToUnitValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, ValueTask> funcAsync,
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
            Unit.InvokeValueAsync(
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
