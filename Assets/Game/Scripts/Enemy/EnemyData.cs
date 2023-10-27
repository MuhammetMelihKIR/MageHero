using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UIElements.Slider;


public class EnemyData : MonoBehaviour
{
    public float maxHp;
    public float currentHp;
    public int damage;
    public int enemyExperience;
    
    protected float MoveSpeed;
    protected float AttackRange;
    protected float AttackCoolTime;
    protected float AttacCoolTimeCacl;
    protected bool CanAtk;
    protected float Distance;

    
    [SerializeField] protected LayerMask PlayerLayer;
    [SerializeField] protected GameObject Player;
    [SerializeField] protected NavMeshAgent NavAgent;
    [SerializeField] protected Animator Animator;
    
    public PlayerController PlayerController;
    public PlayerData playerData;
    public PlayerTarget playerTarget;
    
    
    [Space]
    [Header("EFFECTS")] //EFFECTS
    
    [SerializeField] protected GameObject attackEffect;
    [SerializeField] protected GameObject deathEffect;
    
    
    }
