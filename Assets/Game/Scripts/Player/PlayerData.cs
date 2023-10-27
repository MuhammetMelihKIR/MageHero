using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PlayerData : MonoBehaviour
{
    [Header("CHANGEABLE VALUE")]
    //Değişen özellikler
    [SerializeField] private int maxHealth;  // maksimum can
    [SerializeField] private int currentHealth; // anlık can
    [SerializeField] private int defense; //savunma
    [SerializeField] private int attack;  // hasar
    [SerializeField] private float attackSpeed; //atış hızı
    [SerializeField] private float experiencePoint; //deneyim puanı
    [SerializeField] private int playerLevel; // karakter leveli
    
    [Space]
    [Header("FIXED VALUE")]
    //Değişmeyen özellikler
    [SerializeField] private int moveSpeed;  // karakter hareket hızı
    [SerializeField] private int rotateSpeed; // karakter dönme hızı 
    
    [Space]
    [Header("Effects")]
    public GameObject attackEffect;

    [Space] [Header(("Skills"))]
    public List<int> PlayerSkills = new List<int>();
    
    public int MaxHealth
    {   
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }
    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed= value; }
    }

    public float ExperiencePoint
    {
        get { return experiencePoint; }
        set { experiencePoint = value; }
    }

    public int PlayerLevel
    {
        get { return playerLevel; }
        set { playerLevel= value; }
    }

    public int MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public int RotateSpeed
    {
        get { return rotateSpeed; }
        set { rotateSpeed = value; }
    }
    

    
}
