using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTargetState : State
{
    AttackState attackState;

    private void Awake()
    {
        attackState = GetComponent<AttackState>();
    }

    public override State Tick(EnemyManager enemyManager)
    {
        Debug.Log("Chasing");
        MoveTowarsCurrentTarget(enemyManager);
        if(enemyManager.distanceFromCurrentTarget <= enemyManager.minimumAttackDistance)
        {
            return attackState;
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
