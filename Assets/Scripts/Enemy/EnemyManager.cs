using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    //Th state this character begins on
    public IDLEState startingState;

    //the state this character is currently in
    public State currentState;

    [Header("Current Target")]
    public PlayerManager currentTarget;
    public float distanceFromCurrentTarget;

    [Header("Attack")]
    public float minimumAttackDistance = 1;


    public NavMeshAgent enemyNavMeshAgent;

    private void Awake()
    {
        currentState = startingState;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(currentState != null && currentTarget!=null)
        {
            distanceFromCurrentTarget = Vector3.Distance(currentTarget.transform.position, transform.position);
        }
    }

    private void HandlerStateMachine()
    {
        State nextState;
        if (currentState != null)
        {
            nextState = currentState.Tick(this);

            if(nextState != null)
            {
                currentState = nextState;
            }
        }        
    }

    private void FixedUpdate()
    {
        HandlerStateMachine();
    }
}
