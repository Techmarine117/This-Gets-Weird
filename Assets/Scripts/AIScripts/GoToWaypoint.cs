using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoToWaypoint : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("Waypoint").RemoveResource();
        if (target == null)
            return false;

        inventory.AddItem(target);
        //GWorld.Instance.GetWorld().ModifyState("FreeWaypoint", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetQueue("Waypoint").AddResource(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeWaypoint", 1);
        return true;
    }
}
