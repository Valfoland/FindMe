using Ui;
using UnityEngine;

public class MenuUiScreen : WindowGuiBehaviour
{
    protected MenuUiScreen(GameObject go, WindowType windowType) : base(go, windowType) { }


    protected MenuUiScreen(string prefabPath, RectTransform parent, WindowType windowType) : base(prefabPath, parent, windowType) { }


    protected MenuUiScreen(GameObject template, RectTransform parent, WindowType windowType) : base(template, parent, windowType) { }
}
