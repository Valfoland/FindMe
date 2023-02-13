using Basement.Common;


namespace BusinessLogic
{
    public abstract class ContextCreator
    {
        public abstract PlayerContext CreateContext(RawNode playerProgressNode, RawNode repositoryNode);
    }
}
