using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour //カメラ制御スクリプト
{
    Camera _mainCamera;
    [SerializeField] GameObject[] _moveLimitObj;
    [SerializeField] GameObject _target;
    Vector3 _mouseVector;
    float _mouseScrollValue;
    bool _moveLimit;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        _mouseScrollValue =-1 * Input.mouseScrollDelta.y;
        if (_mainCamera.fieldOfView > 35 && _mainCamera.fieldOfView < 100)
        {
            _mainCamera.fieldOfView += _mouseScrollValue;    
        }
        else if (_mainCamera.fieldOfView <= 35)
        {
            _mainCamera.fieldOfView = 35.1f;
        }
        else if (_mainCamera.fieldOfView >= 100)
        {
            _mainCamera.fieldOfView = 99.9f;
        }
        
        if (_moveLimitObj[0].transform.position.x > transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }

        else if (_moveLimitObj[0].transform.position.z > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
        }

        if (_moveLimitObj[1].transform.position.x < transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }

        else if (_moveLimitObj[1].transform.position.z < transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        }
        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            _mouseVector =
                new Vector3(Input.GetAxisRaw("Mouse X"), 0, Input.GetAxisRaw("Mouse Y"));   //カメラ移動の処理
            transform.position += _mouseVector * 0.03f;
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        if (Input.GetButton("Jump"))    //targetの位置にカメラを固定する
        {
            transform.position =
                new Vector3(_target.transform.position.x, 15f, _target.transform.position.z + -6.5f);
        }
        
        
    }
}