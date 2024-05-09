using UnityEngine;
using UnityEngine.Serialization;

public class RotateObject : MonoBehaviour   //回転するオブジェクトの制御するスクリプト
{
    //ターゲットからの距離
    [FormerlySerializedAs("distanceFromTarget")] [SerializeField]
    Vector3 _distanceFromTarget = new Vector3(2f, 0f, 2f);

    //オブジェクトが消えるまでの時間
    [SerializeField] float _lifeTime = 1f;

    //回転するスピード
    [FormerlySerializedAs("rotateSpeed")] [SerializeField]
    float _rotateSpeed = 180f;

    //旋回するターゲット
    Transform _target;

    //現在の角度
    float _angle;

    //Time.deltaTimeの値を入れておく変数
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        //_timerが_lifeTimeの値を超えたら自身をデストロイする
        if (_lifeTime < _timer)
        {
            Destroy(gameObject);
        }

        //ユニットの位置 = ターゲットの位置 ＋ ターゲットから見たユニットの角度 ×　ターゲットからの距離
        transform.position = _target.position + Quaternion.Euler(0f, _angle, 0f) * _distanceFromTarget;
        //ユニットの角度を変更
        _angle += _rotateSpeed * Time.deltaTime;
    }
}