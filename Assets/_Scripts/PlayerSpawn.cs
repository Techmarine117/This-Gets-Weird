using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Players")
        {
            other.transform.position = spawnPoint.transform.position;
            Debug.Log("work");
        }
    }
}
