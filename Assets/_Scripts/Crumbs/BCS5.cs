using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCS5 : MonoBehaviour
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

    public void TurnCrumbsOn5()
    {
        crumbSpawnerIsActive = true;
        InvokeRepeating("SpawnBreadcrumb", 1f, 8f);
    }

    public void TurnCrumbsOff5()
    {
        crumbSpawnerIsActive = false;
    }
}
