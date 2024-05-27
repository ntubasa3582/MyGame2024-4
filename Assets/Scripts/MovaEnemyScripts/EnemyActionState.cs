using UnityEngine;

[RequireComponent(typeof(EnemyMoveMoba))]
[RequireComponent(typeof(EnemyAttackMoba))]
[RequireComponent(typeof(EnemyDetectionMoba))]
public class EnemyActionState : MonoBehaviour //エネミーの行動を管理するスクリプト
{
    [SerializeField] EnemyAttackMoba _enemyAttackMoba;
    [SerializeField] EnemyDetectionMoba _enemyDetectionMoba;
    [SerializeField] EnemyMoveMoba _enemyMoveMoba;

    public void ChangeSetMove(Vector3 value)        //移動させたいオブジェクトの座標を渡す
    {
        _enemyMoveMoba.SetDestinationChange(value);
    }

    public void AttackSwitch(bool attackSwitch)     //攻撃したいオブジェクトの座標を渡す
    {
        _enemyAttackMoba.Attack(attackSwitch);
    }
}