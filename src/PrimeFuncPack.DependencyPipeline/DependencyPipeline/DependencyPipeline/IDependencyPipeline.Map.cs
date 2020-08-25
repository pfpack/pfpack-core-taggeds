#nullable enable

using System;

namespace PrimeFuncPack.DependencyPipeline
{
    partial interface IDependencyPipeline<T>
    {
        public IDependencyPipeline<TResult> Map<TResult>(
            in Func<T, TResult> mapFunc)
        {
            var map = mapFunc ?? throw new ArgumentNullException(nameof(mapFunc));

            return DependencyPipeline.Start(
                sp => Resolve(sp) switch
                {
                    var value => map.Invoke(value)
                });
        }
    }
}
