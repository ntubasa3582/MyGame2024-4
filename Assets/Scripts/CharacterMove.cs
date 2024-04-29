using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMove : MonoBehaviour //プレイヤーの動きを制御するスクリプト
{
    Rigidbody _rb;
    Vector3 _pressedKeyVector;  //WASDキーいずれかが押された時に取得した値を入れておく変数
    float _moveSpeed = 2;       //characterの移動量を決める変数      

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _pressedKeyVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); //characterの移動処理
        _rb.velocity = _pressedKeyVector * _moveSpeed;
    }
    /// <summary>_moveSpeedの値を変更するメソッド</summary>
    /// <param name="value">変更する値をいれる変数</param>
    public void MoveSpeedValueChange(float value)
    {
        _moveSpeed = value;
    }
}