using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class EnemySpider : EnemyState
{
    private void Start()
    {
        AttackCoolTime = 2f;
        AttacCoolTimeCacl = AttackCoolTime;
        
        MoveSpeed = 4f;
        NavAgent.speed = MoveSpeed;

        Distance = 1.2f;
        NavAgent.stoppingDistance = Distance;
    }

   
    private void OnDrawGizmosSelected()
    {
        AttackRange = 1.2f;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,AttackRange);
    }

    
}
