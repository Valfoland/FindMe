using Basement.Common;
using UnityEngine;


namespace BusinessLogic
{
    public class PlayerContext
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
            
        }
    }
}
