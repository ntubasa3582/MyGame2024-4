using System.Collections;
using UnityEngine;

public class EnemyAttackMoba : MonoBehaviour //エネミーの攻撃を管理するスクリプト
{
    EnemyTargetMoba _enemyTarget;
    [SerializeField] GameObject _enemyBulletPrefab; //敵が発射する弾のプレハブ
    [SerializeField] float _bulletInterval; //弾の生成時間
    float _attackTimer;
    bool _isAttack; //攻撃のオンオフ切り替え

    public void Awake()
    {
        _enemyTarget = GetComponent<EnemyTargetMoba>();
    }

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
                Instantiate(_enemyBulletPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}