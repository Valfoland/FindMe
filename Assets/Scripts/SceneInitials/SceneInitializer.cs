using UnityEngine;


namespace SceneInitials
{
    public abstract class SceneInitializer : MonoBehaviour
    {
        private void Awake()
        {
            Initialize();
        }


        protected abstract void InitializeServices();


        protected abstract void Initialize();
    }
}