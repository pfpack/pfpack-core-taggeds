#nullable enable

using System;

namespace PrimeFuncPack.DependencyPipeline.Extensions
{
    public static class DependencyPipelineExtensions
    {
        public static IDependencyPipeline<(TFirst First, TOther Second)> And<TFirst, TOther>(
            this IDependencyPipeline<TFirst> sourcePipeline,
            in IDependencyPipeline<TOther> otherPipeline)
            where TFirst : class
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            var other = otherPipeline ?? throw new ArgumentNullException(nameof(otherPipeline));

            return sourcePipeline.Pipe(
                (sp, first) => other.Resolve(sp) switch
                {
                    var otherValue => (first, otherValue)
                });
        }

        public static IDependencyPipeline<(TFirst First, TSecond Second, TOther Third)> And<TFirst, TSecond, TOther>(
            this IDependencyPipeline<(TFirst First, TSecond Second)> sourcePipeline,
            in IDependencyPipeline<TOther> otherPipeline)
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            var other = otherPipeline ?? throw new ArgumentNullException(nameof(otherPipeline));

            return sourcePipeline.Pipe(
                (sp, value) => other.Resolve(sp) switch
                {
                    var otherValue => (value.First, value.Second, otherValue)
                });
        }

        public static IDependencyPipeline<(TFirst First, TSecond Second, TThird Third, TOther Fourth)> And<TFirst, TSecond, TThird, TOther>(
            this IDependencyPipeline<(TFirst First, TSecond Second, TThird Third)> sourcePipeline,
            in IDependencyPipeline<TOther> otherPipeline)
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            var other = otherPipeline ?? throw new ArgumentNullException(nameof(otherPipeline));

            return sourcePipeline.Pipe(
                (sp, value) => other.Resolve(sp) switch
                {
                    var otherValue => (value.First, value.Second, value.Third, otherValue)
                });
        }

        public static IDependencyPipeline<(TFirst First, TSecond Second, TThird Third, TFourth Fourth, TOther Fifth)> And<TFirst, TSecond, TThird, TFourth, TOther>(
            this IDependencyPipeline<(TFirst First, TSecond Second, TThird Third, TFourth Fourth)> sourcePipeline,
            in IDependencyPipeline<TOther> otherPipeline)
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            var other = otherPipeline ?? throw new ArgumentNullException(nameof(otherPipeline));

            return sourcePipeline.Pipe(
                (sp, value) => other.Resolve(sp) switch
                {
                    var otherValue => (value.First, value.Second, value.Third, value.Fourth, otherValue)
                });
        }
    }
}
