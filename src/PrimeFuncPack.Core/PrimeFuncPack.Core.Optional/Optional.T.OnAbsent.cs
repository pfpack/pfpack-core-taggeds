﻿#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Unit OnAbsent(in Func<Unit> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return box switch
            {
                null => func.Invoke(),
                _ => default
            };
        }

        public Unit OnAbsent(Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return OnAbsent(func: () => action.InvokeToUnit());
        }

        public Task<Unit> OnAbsentAsync(in Func<Task<Unit>> funcAsync)
        {
            if (funcAsync is null)
            {
                throw new ArgumentNullException(nameof(funcAsync));
            }

            return box switch
            {
                null => funcAsync.Invoke(),
                _ => Task.FromResult<Unit>(default)
            };
        }

        public Task OnAbsentAsync(in Func<Task> funcAsync)
        {
            if (funcAsync is null)
            {
                throw new ArgumentNullException(nameof(funcAsync));
            }

            return box switch
            {
                null => funcAsync.Invoke(),
                _ => Task.CompletedTask
            };
        }

        public ValueTask<Unit> OnAbsentAsync(in Func<ValueTask<Unit>> funcAsync)
        {
            if (funcAsync is null)
            {
                throw new ArgumentNullException(nameof(funcAsync));
            }

            return box switch
            {
                null => funcAsync.Invoke(),
                _ => default
            };
        }

        public ValueTask OnAbsentAsync(in Func<ValueTask> funcAsync)
        {
            if (funcAsync is null)
            {
                throw new ArgumentNullException(nameof(funcAsync));
            }

            return box switch
            {
                null => funcAsync.Invoke(),
                _ => default
            };
        }
    }
}
