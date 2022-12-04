using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = spawnPoint.transform.position;
    }
}
