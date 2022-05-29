using System.Collections.Generic;

namespace Framework
{
    public class UiNode
    {
        public string NodeName { get; private set; }
        public Dictionary<string, string> NeighbourNodes { get; private set; } = new Dictionary<string, string>();
    }
}
