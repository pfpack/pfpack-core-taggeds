#nullable enable

using static System.Strings;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public override string ToString()
            =>
            InternalFold(
                ToStringOrEmpty,
                ToStringOrEmpty);
    }
}
