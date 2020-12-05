#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Unit
    {
        public Task<Unit> ThisAsync()
            =>
            Task.FromResult(this);

        public ValueTask<Unit> ThisValueAsync()
            =>
            ValueTask.FromResult(this);
    }
}
