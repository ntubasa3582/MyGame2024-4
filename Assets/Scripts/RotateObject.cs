using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateObject : MonoBehaviour
{
    //　旋回するターゲット
    [FormerlySerializedAs("target")] [SerializeField] private Transform _target;

    //　現在の角度
    private float _angle;

    //　回転するスピード
    [FormerlySerializedAs("rotateSpeed")] [SerializeField] private float _rotateSpeed = 180f;

    //　ターゲットからの距離
    [FormerlySerializedAs("distanceFromTarget")] [SerializeField] private Vector3 _distanceFromTarget = new Vector3(2f, 1f, 2f);

    // Update is called once per frame
    void Update()
    {
        //　ユニットの位置 = ターゲットの位置 ＋ ターゲットから見たユニットの角度 ×　ターゲットからの距離
        transform.position = _target.position + Quaternion.Euler(0f, _angle, 0f) * _distanceFromTarget;
        //　ユニット自身の角度 = ターゲットから見たユニットの方向の角度を計算しそれをユニットの角度に設定する
        transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(_target.position.x, transform.position.y, _target.position.z), Vector3.up);
        //　ユニットの角度を変更
        _angle += _rotateSpeed * Time.deltaTime;
        //　角度を0～360度の間で繰り返す
        _angle = Mathf.Repeat(_angle, 360f);
    }
}