using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyController : MonoBehaviour
{
    [SerializeField] GameObject[] walkingPoints;
    [SerializeField] float speed = 1.0f;

    int index;

    [SerializeField] bool isLooping = false;
    private void Update()
    {
        if (Vector3.Distance(transform.position, walkingPoints[index].transform.position) < 0.5f)
        {
            index++;
            if (index >= walkingPoints.Length && isLooping)
            {
                index = 0;
            }
        }
        //transform.LookAt(transform.position, walkingPoints[index].transform.position); 
        transform.position = Vector3.MoveTowards(transform.position, walkingPoints[index].transform.position, speed * Time.deltaTime);
    }
}
