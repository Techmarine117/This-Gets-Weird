using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform cubeSpawnPoint;
    [SerializeField] Transform player;
    [SerializeField] GameObject UIObj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FPSPlayer")
        {
            other.transform.position = spawnPoint.transform.position;
        }

        if (other.tag == "pickUp")
        {
            other.transform.position = cubeSpawnPoint.transform.position;
        }
    }

    public void SpawnFunction()
    {
        player.transform.position = spawnPoint.transform.position;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        UIObj.SetActive(false);
        
    }
}
