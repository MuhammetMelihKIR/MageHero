using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerBullet : MonoBehaviour
{
    public PlayerData playerData;
    public PlayerTarget playerTarget;
    [SerializeField] private float BulletSpeed;
    

    private void Start()
    {
        transform.rotation = playerTarget.transform.rotation;
    }

    private void Update()
    {
        BulletMove();
    }

    public void BulletMove()
    {
       
        transform.Translate(Vector3.forward* BulletSpeed * Time.deltaTime);
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Wall") || (other.collider.CompareTag("Enemy")))
        {
            ObjectsPool.Instance.EnqueueObject(gameObject);
        }
        
    }
}
