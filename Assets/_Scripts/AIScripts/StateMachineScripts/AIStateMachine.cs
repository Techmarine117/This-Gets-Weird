using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIStateMachine : MonoBehaviour, IData
{
    public enum State
    {
        Idle,
        Patrol,
        Chase,
        Attack,
    }


    public GameObject attackCol;
    public NavMeshAgent agent;
    public Animator anim;
    public float Patrolspeed, ChaseSpeed;
    public GameObject[] wayPoints;
    public GameObject target;
    public GameObject player;
    AIRayCast Ray;
    public float chaseRange;
    public float attackRange;
    public float killRange;
    public State CurrentState; //Local variable that represents our state
    public float destinationRange;
    public GameObject EndGameObj;




    public void ChangeState(State newState)
    {
        CurrentState = newState;
    }

    private void Start()
    {

        CurrentState = State.Patrol;
        agent = GetComponent<NavMeshAgent>();
        Ray = GetComponent<AIRayCast>();
        //player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        agent.speed = Patrolspeed;
        EndGameObj.SetActive(false);
        Time.timeScale = 1f;

    }
    private void OnEnable()
    {
        agent.speed = Patrolspeed;
        target = null;

    }

    private void Update()
    {
        switch (CurrentState)
        {
            case State.Patrol:
                Patrol();
                if (Ray.PlayerHit == true)
                {
                    agent.speed = chaseRange;
                    ChangeState(State.Chase);
                }
                break;

            case State.Chase:
                Chasing();
                if (Vector3.Distance(player.transform.position, transform.position) > chaseRange)
                {
                    agent.speed = Patrolspeed;
                    target = null;
                    ChangeState(State.Patrol);
                }
                if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
                {
                    ChangeState(State.Attack);
                }
                break;

            case State.Attack:
                Attacking();
                if (Vector3.Distance(player.transform.position, transform.position) > attackRange)
                {
                    ChangeState(State.Chase);
                }
                break;
        }

        Debug.Log(CurrentState);
    }



    public void Patrol()
    {
        if (target == null)
        {
            target = wayPoints[Random.Range(0, wayPoints.Length)];
            agent.SetDestination(target.transform.position);
        }
        if (Vector3.Distance(target.transform.position, transform.position) < destinationRange)
        {
            target = null;
        }
    }



    public void Chasing()
    {
        agent.SetDestination(player.transform.position);
        anim.SetBool("Pounceing", false);
    }

    public void Attacking()
    {
        // attackCol.SetActive(true);
        anim.SetBool("Pounceing", true);
    }
    public void EndGame()
    {
        if(Vector3.Distance(gameObject.transform.position,player.transform.position) <= killRange)
        {
            EndGameObj.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else if (Vector3.Distance(gameObject.transform.position, player.transform.position) > killRange)
        {
            anim.SetBool("Pounceing", false);
        }
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.AIPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.AIPosition = this.transform.position;

    }

}