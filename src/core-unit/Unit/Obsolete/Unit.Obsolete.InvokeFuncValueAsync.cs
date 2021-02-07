#nullable enable

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace System
{
    partial struct Unit
    {
        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync(Func<ValueTask> funcAsync)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T>(Func<T, ValueTask> funcAsync, T obj)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2>(
            Func<T1, T2, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3>(
            Func<T1, T2, T3, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4>(
            Func<T1, T2, T3, T4, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5>(
            Func<T1, T2, T3, T4, T5, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6>(
            Func<T1, T2, T3, T4, T5, T6, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7>(
            Func<T1, T2, T3, T4, T5, T6, T7, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, ValueTask> funcAsync,
            T1 arg1,
            T2 arg2,
            T3 arg3,
            T4 arg4,
            T5 arg5,
            T6 arg6,
            T7 arg7,
            T8 arg8)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask> funcAsync,
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
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, ValueTask> funcAsync,
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
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, ValueTask> funcAsync,
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
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, ValueTask> funcAsync,
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
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, ValueTask> funcAsync,
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
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, ValueTask> funcAsync,
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
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, ValueTask> funcAsync,
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
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);

        [Obsolete(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete, error: true)]
        [DoesNotReturn]
        public static ValueTask<Unit> InvokeFuncValueAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, ValueTask> funcAsync,
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
            throw new NotImplementedException(ObsoleteMessages.MethodInvokeFuncValueAsyncObsolete);
    }
}
