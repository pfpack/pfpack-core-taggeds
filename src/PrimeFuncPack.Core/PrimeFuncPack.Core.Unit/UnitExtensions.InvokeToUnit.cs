#nullable enable

namespace System
{
    partial class UnitExtensions
    {
        public static Unit InvokeToUnit(this Action action)
            =>
            Unit.InvokeAction(action);

        public static Unit InvokeToUnit<T>(this Action<T> action, in T obj)
            =>
            Unit.InvokeAction(action, obj);

        public static Unit InvokeToUnit<T1, T2>(
            this Action<T1, T2> action,
            in T1 arg1,
            in T2 arg2)
            =>
            Unit.InvokeAction(
                action,
                arg1,
                arg2);

        public static Unit InvokeToUnit<T1, T2, T3>(
            this Action<T1, T2, T3> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3)
            =>
            Unit.InvokeAction(
                action,
                arg1,
                arg2,
                arg3);

        public static Unit InvokeToUnit<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4)
            =>
            Unit.InvokeAction(
                action,
                arg1,
                arg2,
                arg3,
                arg4);

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5>(
            this Action<T1, T2, T3, T4, T5> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5)
            =>
            Unit.InvokeAction(
                action,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5);

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6>(
            this Action<T1, T2, T3, T4, T5, T6> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6)
            =>
            Unit.InvokeAction(
                action,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6);

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7>(
            this Action<T1, T2, T3, T4, T5, T6, T7> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7)
            =>
            Unit.InvokeAction(
                action,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7);

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7, T8>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8)
            =>
            Unit.InvokeAction(
                action,
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8);

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8,
            in T9 arg9)
            =>
            Unit.InvokeAction(
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

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8,
            in T9 arg9,
            in T10 arg10)
            =>
            Unit.InvokeAction(
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

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8,
            in T9 arg9,
            in T10 arg10,
            in T11 arg11)
            =>
            Unit.InvokeAction(
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

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8,
            in T9 arg9,
            in T10 arg10,
            in T11 arg11,
            in T12 arg12)
            =>
            Unit.InvokeAction(
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

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8,
            in T9 arg9,
            in T10 arg10,
            in T11 arg11,
            in T12 arg12,
            in T13 arg13)
            =>
            Unit.InvokeAction(
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

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8,
            in T9 arg9,
            in T10 arg10,
            in T11 arg11,
            in T12 arg12,
            in T13 arg13,
            in T14 arg14)
            =>
            Unit.InvokeAction(
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

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8,
            in T9 arg9,
            in T10 arg10,
            in T11 arg11,
            in T12 arg12,
            in T13 arg13,
            in T14 arg14,
            in T15 arg15)
            =>
            Unit.InvokeAction(
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

        public static Unit InvokeToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8,
            in T9 arg9,
            in T10 arg10,
            in T11 arg11,
            in T12 arg12,
            in T13 arg13,
            in T14 arg14,
            in T15 arg15,
            in T16 arg16)
            =>
            Unit.InvokeAction(
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
