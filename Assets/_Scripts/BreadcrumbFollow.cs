using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BreadcrumbFollow : MonoBehaviour
{
    NavMeshAgent crumbAgent;

    public Transform crumbTarget;

    float stopDistance = 1f;

    private void Start()
    {
        crumbAgent = GetComponent<NavMeshAgent>();

        crumbAgent.SetDestination(crumbTarget.position);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, crumbTarget.position) < stopDistance)
        {
            Destroy(gameObject);
        }
    }
}
