#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Unit
    {
        public static implicit operator Task<Unit>(in Unit unit)
            =>
            unit.ThisAsync();

        public static implicit operator ValueTask<Unit>(in Unit unit)
            =>
            unit.ThisValueAsync();
    }
}
