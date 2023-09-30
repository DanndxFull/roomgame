using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDLEState : State
{
    private PursueTargetState pursueTargetState;


    [Header("Detection Layer")]
    [SerializeField] LayerMask detectionLayer;

    [Header("Line of sight detection")]
    [SerializeField] float characterEyeLevel = 1.8f;
    [SerializeField] LayerMask ignoreForLineOfSightDetection;

    [Header("Detection Radius")]
    [SerializeField] float detectionRadius = 5;


    [Header("Detection Angle Radius")]
    [SerializeField] float minimunDetectionRadiusAngle = -100;
    [SerializeField] float maximumDetectionRadiusAngle = 180;

    //IDLE the enemy until he find a target
    //if a target found proceed to chase state
    //if no target stay in IDLE

    private void Awake()
    {
        pursueTargetState = GetComponent<PursueTargetState>();
    }

    [SerializeField] private bool hasTarget;
    public override State Tick(EnemyManager enemyManager)
    {
        if (enemyManager.currentTarget != null)
        {
            Debug.Log("Found Something");
            return pursueTargetState;
        }
        else
        {
            Debug.Log("Found nothing");
            FindATargetViaLineOfSight(enemyManager);
            return this;
        }
    }

    private void FindATargetViaLineOfSight(EnemyManager enemyManager)
    {
        //We are searching all colliders on the layer of the player within a certain radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            PlayerManager player = colliders[i].transform.GetComponent<PlayerManager>();

            if (player != null)
            {
                Vector3 targetDirection = transform.position - player.transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if (viewableAngle > minimunDetectionRadiusAngle && viewableAngle < maximumDetectionRadiusAngle)
                {
                    RaycastHit hit;
                    Vector3 playerStartPoint = new Vector3(player.transform.position.x, characterEyeLevel, player.transform.position.z);
                    Vector3 enemyStartPoint = new Vector3(transform.position.x, characterEyeLevel, transform.position.z);
                    //check for objects blocking

                    Debug.DrawLine(playerStartPoint, enemyStartPoint, Color.yellow);
                    if (Physics.Linecast(playerStartPoint, enemyStartPoint, out hit, ignoreForLineOfSightDetection))
                    {
                        Debug.Log("Hay algo en el camino");
                        //cannot do anything
                    }
                    else
                    {
                        Debug.Log("Encontrao");
                        enemyManager.currentTarget = player;
                    }
                }
            }
        }
    }
}
