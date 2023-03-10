using Basement.Common;
using Basement.OEPFramework.UnityEngine.Behaviour;


namespace Ui.GuiEffects
{
    public abstract class GuiEffect : ControlLoopBehaviour
    {
        protected readonly WeakRef<WindowGuiBehaviour> weakGUIBehaviour;

        public GuiEffectState State { get; protected set; }


        protected GuiEffect(WindowGuiBehaviour guiBehaviour = null)
        {
            if (guiBehaviour != null)
            {
                weakGUIBehaviour = new WeakRef<WindowGuiBehaviour>(guiBehaviour);
            }
        }


        public abstract void Show();


        public abstract void Hide();
    }
}