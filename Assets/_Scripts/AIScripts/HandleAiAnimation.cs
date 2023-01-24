using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandleAiAnimation : MonoBehaviour
{
    public AIStateMachine aIStateMachine;
    Animator animator;
    NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {
        aIStateMachine= GetComponent<AIStateMachine>();
        animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Speed", Agent.velocity.magnitude);
        

    }


    

   
}
