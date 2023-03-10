using UnityEngine;


namespace Ui.TransitionScreens
{
    public abstract class TransitionScreen : WindowGuiBehaviour
    {
        public abstract void Transit();


        protected TransitionScreen(GameObject template, RectTransform parent, WindowType windowType) : base(template, parent, windowType) { }
    }
}