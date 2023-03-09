using Basement.Common;
using Basement.OEPFramework.UnityEngine.Behaviour;


namespace Ui.GuiEffects
{
    public abstract class GuiEffect : ControlLoopBehaviour
    {
        protected readonly WeakRef<DynamicGuiBehaviour> weakGUIBehaviour;

        public GuiEffectState State { get; protected set; }


        protected GuiEffect(DynamicGuiBehaviour guiBehaviour = null)
        {
            if (guiBehaviour != null)
            {
                weakGUIBehaviour = new WeakRef<DynamicGuiBehaviour>(guiBehaviour);
            }
        }


        public abstract void Show();


        public abstract void Hide();
    }
}