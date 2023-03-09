using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTesting : MonoBehaviour
{
    //[SerializeField] GameObject destination;
    //[SerializeField] float speed = 2;
    Animator animator;

    private void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
