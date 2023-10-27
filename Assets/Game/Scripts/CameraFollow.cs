using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraFollow : MonoBehaviour
{
       [SerializeField] private Transform Player;
   
       [SerializeField] private float Speed;
        
       private Vector3 _offset;
       
       private Transform _camera;
   
       
   
       private void Awake()
       {
           _camera = this.transform;
           _offset = new Vector3(Player.position.x, Player.position.y, -3);
       }
   
       private void Update()
       {
           Follow();
       }
   
       private void Follow()
       {
          _camera.DOMoveZ(Player.position.z + _offset.z, Speed * Time.deltaTime);
       }
}
