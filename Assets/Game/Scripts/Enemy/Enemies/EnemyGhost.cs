using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : EnemyState
{
    private void Start()
    {
        AttackCoolTime = 2f;
        AttacCoolTimeCacl = AttackCoolTime;
        
        MoveSpeed = 5f;
        NavAgent.speed = MoveSpeed;

        Distance = 1.5f;
        NavAgent.stoppingDistance = Distance;
    }

   
    private void OnDrawGizmosSelected()
    {
        AttackRange = 1.5f;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,AttackRange);
    }
}
