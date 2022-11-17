using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : GAgent
{
    AIRayCast Ray;

    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();

        SubGoal s1 = new SubGoal("Chase", 1, false);
        goal.Add(s1, 1);

        SubGoal s2 = new SubGoal("Waypoints", 2, false);
        goal.Add(s2 , 2);

        SubGoal s3 = new SubGoal("FindNextWaypoint", 3, false);
        goal.Add(s3, 3);


    }

    public void Update()
    {
        void GaveChase()
        {
            beliefs.ModifyState("Chaseing", 0);
        }
        Ray.FindVisibleTargets();

        if (Ray.PlayerHit == true)
        {
            Debug.Log("playerSeenChaseing");
            GaveChase();
        }else
        {

        }


      
        
    }




}
