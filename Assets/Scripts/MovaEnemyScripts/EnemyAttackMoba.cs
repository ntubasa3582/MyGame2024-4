using System.Collections;
using UnityEngine;

public class EnemyAttackMoba : MonoBehaviour //エネミーの攻撃を管理するスクリプト
{
    [SerializeField] GameObject _enemyBulletPrefab; //敵が発射する弾のプレハブ
    [SerializeField] float _bulletSpeed; //弾の移動速度
    [SerializeField] float _bulletInterval; //弾の生成時間
    Vector3 _attackTarget;
    float _attackTimer;
    bool _isAttack; //攻撃のオンオフ切り替え

    public void Attack(bool attackSwitch) //攻撃処理
    {
        _isAttack = attackSwitch;
    }

    void Update()
    {
        if (_isAttack)
        {
            _attackTimer += Time.deltaTime;
            if (_bulletInterval < _attackTimer)
            {
                _attackTimer = 0;
                Debug.Log("攻撃");
                GameObject bullet = Instantiate(_enemyBulletPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}