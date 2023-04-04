using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoyController : MonoBehaviour
{
    [SerializeField] GameObject[] walkingPoints;
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform Player;
    [SerializeField] float PlayerRange;
    [SerializeField] bool isLooping = false;
    [SerializeField] float pauseLength = 3f;
    public NavMeshAgent agent;
    int index;
    public float destinationRange;

    //private void LateUpdate()
    //{
    //    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    //}
    private void Start()
    {
        StartCoroutine(Patrol());
    }

    private void Update()
    {
        
        var distance = Vector3.Distance(transform.position, Player.position);
        if ( distance >= PlayerRange)
        {
            agent.speed = 0;
        }
        else 
        {
            agent.speed = speed;
        }
        //Debug.Log(Vector3.Distance(transform.position, Player.position));
    }

    private void RotateToDirection()
    {

        //transform.Rotate(walkingPoints[index].transform.position, Time.deltaTime);
    }

    public IEnumerator Patrol()
    {
        if (Vector3.Distance(transform.position, walkingPoints[index].transform.position) < destinationRange)
        {
            
            index++;
            if (index >= walkingPoints.Length && isLooping)
            {
                index = 0;
            }
            
            
        }
        agent.SetDestination(walkingPoints[index].transform.position);
        yield return new WaitForSeconds(pauseLength);
        StartCoroutine(Patrol());
    }
}