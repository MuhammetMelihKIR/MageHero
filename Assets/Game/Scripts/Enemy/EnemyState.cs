using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyState : EnemyData,IDamageable
{
   // protected Slider healthBar;
    public enum State
    {
        Move,Attack,TakeDamage
    }

    public State currentState = State.Move;

    private void Awake()
    {
        currentHp = maxHp;
        //healthBar.highValue = maxHp;
    }

    private void Update()
    {
        NavAgent.transform.LookAt(Player.transform);
        CanAtk = Physics.CheckSphere(transform.position, AttackRange, PlayerLayer);
        if (CanAtk) { currentState = State.Attack; }
        if (!CanAtk) { currentState = State.Move; }

        switch (currentState)
        {
            case State.Move:
                Move();
                break;
            case State.Attack:
                Attack();
                break; 
            case State.TakeDamage:
                break;
                
        }
    }

    public void TakeDamage(int damage)
    {
        
        currentHp -= damage;
       // healthBar.value = currentHp;
        if (currentHp <=0 )
        {
            Instantiate(deathEffect,transform.position, Quaternion.Euler(90, 0, 0));
            gameObject.SetActive(false);
            playerTarget.TargetEnemy = null;

        }
    }

    public void Damage(int damageAmount)
    {
        TakeDamage(damageAmount);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            PlayerController.Damage(damage);
        }
       
        if (other.collider.CompareTag("PlayerBullet"))
        {
            Damage(playerData.Attack);
            Instantiate(attackEffect,transform.position,Quaternion.Euler(0,0,0));
            
        }
    }

    protected void Move()
    {
        Animator.SetTrigger("Walk");
        NavAgent.SetDestination(Player.transform.position);
        
        
    }

    protected void Attack()
    {
        Animator.SetTrigger("Attack");
        
        
        
    }
    
}
