using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    IDLEState iDLEState;
    private void Awake()
    {
        iDLEState = GetComponent<IDLEState>();
    }

    public override State Tick(EnemyManager enemyManager)
    {
        Debug.Log("Attacking State");
        if (enemyManager.distanceFromCurrentTarget >= 5)
        {
            return iDLEState;
        }
        return this;
    }
}
