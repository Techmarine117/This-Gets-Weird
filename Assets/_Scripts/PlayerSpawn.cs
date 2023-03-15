using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FPSPlayer")
        {
            other.transform.position = spawnPoint.transform.position;
            Debug.Log("work");
        }
    }
}
