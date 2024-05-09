using System.Threading;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class BulletController : MonoBehaviour
{
    GameObject _player;
    Rigidbody _rb;
    Vector3 _bulletDirection;
    float _timer;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _bulletDirection = _player.transform.forward;
        _bulletDirection.y = 0;
    }
    
    void Update()
    {
        _rb.AddForce(_bulletDirection,ForceMode.Impulse);
        _timer += Time.deltaTime;
        if (_timer > 5)
        {
            Destroy(gameObject);
        }
    }
}
