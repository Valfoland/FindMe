using System;

namespace Frameworks.OEPFramework.UnityEngine._Base
{
    public interface IDroppableItem
    {
        bool dropped { get; }
        event Action<IDroppableItem> onDrop;
        void Drop();
        bool Reuse();
    }
}
