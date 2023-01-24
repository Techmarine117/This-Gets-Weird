using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackPlayer : GAction
{
    public float attackRange;
    public int Damage;

    public override bool PrePerform()
    {
        Debug.Log("Attack");
        return true;
    }

    public override bool PostPerform()
    {
        if (Vector3.Distance(target.transform.position, gameObject.transform.position) <= attackRange)
        {
           
        }
        return true;
    }
}
