using Basement.Common;


namespace BusinessLogic.ContextFactory
{
    public class DefaultPlayerContextCreator : ContextCreator
    {
        public override PlayerContext CreateContext(RawNode playerProgressNode, RawNode repositoryNode)
        {
            return new PlayerContext(playerProgressNode, repositoryNode);
        }
    }
}
