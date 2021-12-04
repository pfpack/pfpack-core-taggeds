using System;

namespace PrimeFuncPack.Core;

partial struct FailureBuilder<TFailure>
{
    public override string ToString()
        =>
        failure.ToString().OrEmpty();
}
