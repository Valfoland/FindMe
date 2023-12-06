using Basement.Common;


namespace BusinessLogic.ContextFactory
{
    public class PlayerContextCreator
    {
        public PlayerContext CreateContext(RawNode playerProgressNode, RawNode repositoryNode)
        {
            return new PlayerContext(playerProgressNode, repositoryNode);
        }
    }
}
