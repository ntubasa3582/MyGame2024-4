using System;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float _speedParameter;
    GameObject _target;
    float _playerDistance;
    float _moveSpeed;
    bool _playerDetection;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Character");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < 5)
        {
            _playerDetection = true;
        }
        if (_playerDetection)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) > 2.5f)
            {
                _moveSpeed = _speedParameter * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _moveSpeed);
                transform.LookAt(_target.transform.position);
            }
            else
            {
                transform.LookAt(_target.transform.position);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //攻撃判定のあるオブジェクトに触れたら自身をデストロイする
        if (other.gameObject.CompareTag("Attack"))
        {
            Destroy(gameObject);
        }
    }
}
