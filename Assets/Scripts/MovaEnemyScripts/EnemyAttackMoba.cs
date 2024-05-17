using System;
using UnityEngine;

public class EnemyAttackMoba : MonoBehaviour        //エネミーの攻撃を管理するスクリプト
{
    EnemyActionState _enemyAction;
    [SerializeField] GameObject _enemyBullet;       //敵が発射する弾
    [SerializeField] float _attackInterval = 1;
    [SerializeField, Header("Trueが遠距離攻撃 Falseが近距離攻撃")] bool AttackModeSwitch;       //近距離攻撃と遠距離攻撃を切り替える変数
    float _timer;       //攻撃インターバル
    bool _attackStop;                               //攻撃をやめる変数 Trueの時に攻撃
    
    void Awake()
    {
        _enemyAction = FindObjectOfType<EnemyActionState>();
    }

    void Update()
    {
        if (_attackStop)
        {
        }
    }

    public void RangeAttack(GameObject _target)      //遠距離攻撃
    {
        Instantiate(_enemyBullet, transform.position, Quaternion.identity);
    }
}
