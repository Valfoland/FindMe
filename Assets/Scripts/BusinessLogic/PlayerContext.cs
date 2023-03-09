using Basement.Common;
using UnityEngine;
using Zenject;


namespace BusinessLogic
{
    public class PlayerContext : IInitializable
    {
        private readonly RawNode _playerProgressNode;
        private readonly RawNode _repositoryNode;
        
        public PlayerContext(RawNode playerProgressNode, RawNode repositoryNode)
        {
            _playerProgressNode = playerProgressNode;
            _repositoryNode = repositoryNode;
        }
        
        public void Initialize()
        {
            Debug.LogError("INIT");
        }
    }
}
