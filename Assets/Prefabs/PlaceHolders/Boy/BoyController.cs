using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyController : MonoBehaviour
{
    [SerializeField] GameObject[] walkingPoints;
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform Player;
    [SerializeField] float PlayerRange;
    [SerializeField] bool isLooping = false;

    int index;
    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
    
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
        //if (Vector3.Distance(transform.position, Player.position) <= PlayerRange)
        //{
            transform.position = Vector3.MoveTowards(transform.position, walkingPoints[index].transform.position, speed * Time.deltaTime);
        //}
        RotateToDirection();
        Debug.Log(Vector3.Distance(transform.position, Player.position));
    }

    private void RotateToDirection()
    {

        transform.Rotate(walkingPoints[index].transform.position, Time.deltaTime);
    }
}
