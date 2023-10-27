using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private GameObject playerCanvas;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI hpText;
    
    private Vector3 _moveVector;
    private float _lastShoot;
    
    private Rigidbody _rigidbody;
    private Animator _animator;
    

    private PlayerTarget _playerTarget;
    private PlayerData _playerData;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _playerData = GetComponent<PlayerData>();
        _playerTarget = GetComponent<PlayerTarget>();
        
        _playerData.CurrentHealth = _playerData.MaxHealth;
        healthBar.maxValue = _playerData.MaxHealth;
        hpText.text = _playerData.CurrentHealth.ToString();
        

    }
    private void Update()
    {
        Move();
        PlayerCanvasPosition();
    }

    public void TakeDamage(int damage)
    {
        
        _playerData.CurrentHealth -=  (damage/_playerData.Defense)*2;
        healthBar.value = _playerData.CurrentHealth;
        hpText.text = _playerData.CurrentHealth.ToString();
        Instantiate(_playerData.attackEffect, transform.position+new Vector3(0,2,0), Quaternion.Euler(0, 0, 0));
        
        if (_playerData.CurrentHealth <=0 )
        {
            // TODO GAME OVER 
        }
    }

    public void Damage(int damageAmount)  // interface
    {
        TakeDamage(damageAmount);
    }
    private void PlayerCanvasPosition()
    {
        playerCanvas.transform.position = new Vector3(transform.position.x, playerCanvas.transform.position.y, transform.position.z);
    }
    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = joystick.Horizontal * _playerData.MoveSpeed * Time.deltaTime;
        _moveVector.z = joystick.Vertical * _playerData.MoveSpeed * Time.deltaTime;

        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _playerData.RotateSpeed* Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
            
            _animator.SetTrigger("Run");
        }

        else if(joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            if (_playerTarget.TargetEnemy==null)  // IDLE Animasyonu
            {
                transform.LookAt(Vector3.zero);
                _animator.SetTrigger("Idle");
            }
            
            
            transform.LookAt(_playerTarget.TargetEnemy.transform.position); // karakter idle pozisyonuna geçtiği zaman en yakın rakibe döner.
            if (Time.time - _lastShoot < _playerData.AttackSpeed) // ateş etmek için beklem süresi
            {
                return;
            }
            _lastShoot = Time.time;
            ObjectsPool.Instance.DequeueObject();
            _animator.SetTrigger("Attack");

           
        }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }
}
