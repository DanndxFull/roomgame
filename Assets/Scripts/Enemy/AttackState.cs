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
        //return iDLEState;
        return this;
    }
}
