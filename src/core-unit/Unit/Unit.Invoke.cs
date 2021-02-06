#nullable enable

namespace System
{
    partial struct Unit
    {
        public static Unit Invoke(Action action)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke();

            return default;
        }

        public static Unit Invoke<T>(Action<T> action, T obj)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(obj);

            return default;
        }

        public static Unit Invoke<T1, T2>(
            Action<T1, T2> action,
            T1 arg1,
            T2 arg2)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2);

            return default;
        }

        public static Unit Invoke<T1, T2, T3>(
            Action<T1, T2, T3> action,
            T1 arg1,
            T2 arg2,
            T3 arg3)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2,
                arg3);

            return default;
        }

        public static Unit Invoke<T1, T2, T3, T4>(
            Action<T1, T2, T3, T4> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));

            action.Invoke(
                arg1,
                arg2,
                arg3,
                arg4);

            return default;
        }

        public static Unit Invoke<T1, T2, T3, T4, T5>(
            Action<T1, T2, T3, T4, T5> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5)
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6>(
            Action<T1, T2, T3, T4, T5, T6> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6)
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7>(
            Action<T1, T2, T3, T4, T5, T6, T7> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7)
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7, T8>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8)
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8,
            T9 arg9)
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
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

        public static Unit Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
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
