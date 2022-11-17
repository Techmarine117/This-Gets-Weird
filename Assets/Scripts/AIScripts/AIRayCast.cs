using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AIRayCast : MonoBehaviour
{
    
    
    public float ViewRadius;
    [Range(0,360)]
    public float ViewAngle;
    public bool PlayerHit;
    public LayerMask targetMask;
    public LayerMask ObstacleMask;
    public GameObject PlayerReference;

    private void Start()
    {
        PlayerReference = GameObject.FindGameObjectWithTag("PLayer");
        StartCoroutine(FOVRout());
    }

    private IEnumerator FOVRout()
    {
       
        WaitForSeconds Wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return Wait;
            FindVisibleTargets();
        }
    }

    

    public void FindVisibleTargets()
    {
        Debug.Log("FINDING VISIBLE TARGETS");
        Collider[] RangeChecks = Physics.OverlapSphere(transform.position, ViewRadius, targetMask);

        if(RangeChecks.Length != 0)
        {
            Transform Target = RangeChecks[0].transform;
            Vector3 DirToTarget = (Target.position - transform.position).normalized;

            if (Vector3.Angle(transform.position, DirToTarget) < ViewAngle / 2)
            {
                float DisToTarget = Vector3.Distance(transform.forward, Target.position);

                if(!Physics.Raycast(transform.position, DirToTarget, DisToTarget, ObstacleMask))
                {
                    PlayerHit= true;
                }
                else
                    PlayerHit = false;
            }
            else
                PlayerHit = false;
        }
        else if (PlayerHit)
            PlayerHit= false;


    }

    
    


    
}
