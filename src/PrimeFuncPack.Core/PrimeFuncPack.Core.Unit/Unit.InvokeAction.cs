#nullable enable

namespace System
{
    partial struct Unit
    {
        public static Unit InvokeAction(in Action action)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke();

            return default;
        }

        public static Unit InvokeAction<T>(in Action<T> action, in T obj)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(obj);

            return default;
        }

        public static Unit InvokeAction<T1, T2>(
            in Action<T1, T2> action,
            in T1 arg1,
            in T2 arg2)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2);

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3>(
            in Action<T1, T2, T3> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2,
                arg3);

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4>(
            in Action<T1, T2, T3, T4> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2,
                arg3,
                arg4);

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5>(
            in Action<T1, T2, T3, T4, T5> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2,
                arg3,
                arg4,
                arg5);

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6>(
            in Action<T1, T2, T3, T4, T5, T6> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6);

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7>(
            in Action<T1, T2, T3, T4, T5, T6, T7> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7);

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7, T8>(
            in Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8);

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            in Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
            in T1 arg1,
            in T2 arg2,
            in T3 arg3,
            in T4 arg4,
            in T5 arg5,
            in T6 arg6,
            in T7 arg7,
            in T8 arg8,
            in T9 arg9)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2,
                arg3,
                arg4,
                arg5,
                arg6,
                arg7,
                arg8,
                arg9);

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            in Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
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
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
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

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            in Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
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
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
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

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            in Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
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
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
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

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            in Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
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
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
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

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            in Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
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
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
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

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            in Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
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
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
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

            return default;
        }

        public static Unit InvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            in Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
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
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
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

            return default;
        }
    }
}
