using System;
using UnityEngine;

public class EnemyActionState : MonoBehaviour            //エネミーの行動を管理するスクリプト
{
    EnemyAttackMoba _enemyAttackMoba;
    EnemyDetectionMoba _enemyDetectionMoba;
    EnemyMoveMoba _enemyMoveMoba;

    private void Awake()
    {
        _enemyAttackMoba = FindObjectOfType<EnemyAttackMoba>();
        _enemyDetectionMoba = FindObjectOfType<EnemyDetectionMoba>();
        _enemyMoveMoba = FindObjectOfType<EnemyMoveMoba>();
    }

    void Update()
    {
        
    }
    
    


    enum ActionState      //自身の行動を管理する変数
    {
        DefaultMove,
        Attack,
        NewTarget
    }

    public void ChangeSetMove(Vector3 value)
    {
        _enemyMoveMoba.SetDestinationChange(value);
    }
    
}
