using Basement.Common;


namespace BusinessLogic
{
    public class ContextCreator
    {
        public PlayerContext CreateContext(RawNode rootNode)
        {
            return new PlayerContext(rootNode);
        }
    }
}
