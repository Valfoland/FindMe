using System;
using Basement.BLFramework.Core.Context;
using Basement.BLFramework.Core.Reference.Description;
using Basement.Common;
using Ui;

public class UiWindowDescription : DescriptionBase
{
    private const string WindowTypeKey = "window-type";
    private const string ResourcePathKey = "resource-path";

    public WindowType WindowType { get; }
    public string ResourcePath { get; }

    public UiWindowDescription(RawNode node, IContext context = null) : base(node, context)
    {
        if (Enum.TryParse(typeof(WindowType), node.GetString(WindowTypeKey), true, out var value))
        {
            WindowType = (WindowType)value;
        }

        ResourcePath = node.GetString(ResourcePathKey);
    }
}