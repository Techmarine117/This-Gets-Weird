using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCS2 : MonoBehaviour
{
    [SerializeField] GameObject breadcrumb;
    [SerializeField] Transform target;

    bool crumbSpawnerIsActive = false;

    void SpawnBreadcrumb()
    {
        if (target != null && crumbSpawnerIsActive)
        {
            var spawnPos = transform.position + (transform.forward * 2);
            var newObj = Instantiate(breadcrumb, spawnPos, transform.rotation);
            newObj.GetComponent<BreadcrumbFollow>().crumbTarget = target;
        }
    }

    public void TurnCrumbsOn2()
    {
        crumbSpawnerIsActive = true;
        InvokeRepeating("SpawnBreadcrumb", 1f, 8f);
    }

    public void TurnCrumbsOff2()
    {
        crumbSpawnerIsActive = false;
    }
}
