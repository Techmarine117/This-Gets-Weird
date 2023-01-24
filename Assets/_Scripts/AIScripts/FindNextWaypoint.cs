using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNextWaypoint : GAction
{
    

    public override bool PrePerform()
    {
       
        inventory.AddItem(target);

       
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetQueue("Waypoint").AddResource(target);
        inventory.RemoveItem(target);
        return true;
    }
}
