using System.Collections;
using System.Collections.Generic;
using Basement.BLFramework.Core.Context;
using Basement.BLFramework.Core.Reference.Description;
using Basement.Common;
using UnityEngine;

public class UiWindowsDataSource : DataSourceBase<UiWindowDescription>
{
    public UiWindowsDataSource(RawNode node, IContext context = null) : base(node, context)
    {
    }

    protected override UiWindowDescription Factory(RawNode partialNode)
    {
        return new UiWindowDescription(partialNode, GetContext());
    }
}
