using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;
    
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(this.transform.forward * _bulletSpeed);
    }
}
