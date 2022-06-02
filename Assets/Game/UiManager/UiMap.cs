using Game.BusinessLogic;
using Game.BusinessLogic.Descriptions;
using UnityEngine;

namespace Game.UiManager
{
    public class UiMap
    {
        public UiMap()
        {
            InitMap();
        }

        private void InitMap()
        {
            var h = GameManager.context.GetChild<UiMapDescriptionCollection>(DataUtil.Entities.UiMap);

            foreach (var item in h)
            {
                Debug.LogError(item.Value.TransitionTo);
            }
        }
    }
}
