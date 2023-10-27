using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget: MonoBehaviour
{
    public GameObject TargetEnemy;

    private void Update()
    {
       FindClosestEnemy();
    }

    private void FindClosestEnemy()
    {
        
        float distanceClosestEnemy = Mathf.Infinity;
       // Enemy closestEnemy = null;
        EnemyData[] allEnemies = GameObject.FindObjectsOfType<EnemyData>();

        foreach (EnemyData currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceClosestEnemy)
            {
                distanceClosestEnemy = distanceToEnemy;
              //  closestEnemy = currentEnemy;
                TargetEnemy = currentEnemy.gameObject;
                
            }
        }
        Debug.DrawLine( this.transform.position,TargetEnemy.transform.position,Color.green);
        
        
    }

    
}
