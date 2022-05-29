
using TempGame;
using TempGame.Descriptions;

namespace UiFramework
{
    public class UiMap
    {
        public UiMap()
        {
            
        }

        private void InitMap()
        {
            var h = (UiNodeDataSource) GameManager.context.GetChild(GameContext.Entities.UiMap);
        }
    }
}
