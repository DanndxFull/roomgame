using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTargetState : State
{
    AttackState attackState;
    IDLEState iDLEState;

    public Transform playerTransform;
    RaycastHit hit;
    [SerializeField] LayerMask ignoreForLineOfSightDetection;
    private void Awake()
    {
        attackState = GetComponent<AttackState>();
        iDLEState = GetComponent<IDLEState>();
    }

    public override State Tick(EnemyManager enemyManager)
    {
        Debug.Log("Chasing");
        MoveTowarsCurrentTarget(enemyManager);
        if(enemyManager.distanceFromCurrentTarget <= enemyManager.minimumAttackDistance)
        {
            return attackState;
        }
        else if (Physics.Linecast(playerTransform.position,transform.position,out hit, ignoreForLineOfSightDetection))
        {
            Debug.Log("Ya no se encuentra");
            enemyManager.currentTarget = null;
            return iDLEState;
        }
        else
        {
            return this;
        }
    }

    private void MoveTowarsCurrentTarget(EnemyManager enemyManager)
    {
        enemyManager.enemyNavMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
    }
}
