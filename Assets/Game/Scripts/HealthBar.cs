using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;


    private void Update()
    {
        transform.rotation = Camera.transform.rotation;
        transform.position = target.position + offset;
    }
}
