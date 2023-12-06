using System;
using UnityEngine.SceneManagement;

namespace Helpers
{
    public static class StatesSwitchingHelper
    {
        public const string MenuSceneName = "Menu";
        public const string MatchSceneName = "Match";

        public static void SwitchTo(string sceneName)
        {
            GC.Collect();
            SceneManager.LoadScene(sceneName);
        }
    }
}