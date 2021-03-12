#nullable enable

namespace System
{
    partial class UnitExtensions
    {
        public static Unit InvokeThenToUnit(this Action action)
            =>
            Unit.Invoke(action);

        public static Unit InvokeThenToUnit<T>(this Action<T> action, T obj)
            =>
            Unit.Invoke(action, obj);

        public static Unit InvokeThenToUnit<T1, T2>(
            this Action<T1, T2> action,
            T1 arg1,
            T2 arg2)
            =>
            Unit.Invoke(
                action,
                arg1,
                arg2);

        public static Unit InvokeThenToUnit<T1, T2, T3>(
            this Action<T1, T2, T3> action,
            T1 arg1,
            T2 arg2,
            T3 arg3)
            =>
            Unit.Invoke(
                action,
                arg1,
                arg2,
                arg3);

        public static Unit InvokeThenToUnit<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4)
            =>
            Unit.Invoke(
                action,
                arg1,
                arg2,
                arg3,
                arg4);

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5>(
            this Action<T1, T2, T3, T4, T5> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5)
            =>
            Unit.Invoke(
                action,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5);

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6>(
            this Action<T1, T2, T3, T4, T5, T6> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6)
            =>
            Unit.Invoke(
                action,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6);

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7>(
            this Action<T1, T2, T3, T4, T5, T6, T7> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7)
            =>
            Unit.Invoke(
                action,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7);

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7, T8>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8)
            =>
            Unit.Invoke(
                action,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8);

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
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
            Unit.Invoke(
                action,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9);

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
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
            Unit.Invoke(
                action,
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

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
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
            Unit.Invoke(
                action,
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

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
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
            Unit.Invoke(
                action,
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

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
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
            Unit.Invoke(
                action,
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

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
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
            Unit.Invoke(
                action,
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

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
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
            Unit.Invoke(
                action,
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

        public static Unit InvokeThenToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
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
            Unit.Invoke(
                action,
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
