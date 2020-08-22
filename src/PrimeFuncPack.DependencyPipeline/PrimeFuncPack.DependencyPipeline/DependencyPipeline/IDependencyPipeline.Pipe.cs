#nullable enable

using System;

namespace PrimeFuncPack.DependencyPipeline
{
    partial interface IDependencyPipeline<T>
    {
        public IDependencyPipeline<TResult> Pipe<TResult>(
            in Func<IServiceProvider, T, TResult> pipeFunc)
        {
            var pipe = pipeFunc ?? throw new ArgumentNullException(nameof(pipeFunc));

            return DependencyPipeline.Start(
                sp => Resolve(sp) switch
                { 
                    var value => pipe.Invoke(sp, value)
                });
        }
    }
}