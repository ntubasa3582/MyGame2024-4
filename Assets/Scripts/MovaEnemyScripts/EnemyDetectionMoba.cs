using UnityEngine;

public class EnemyDetectionMoba : MonoBehaviour //エネミーと他オブジェクトの距離を管理するスクリプト
{
    EnemyActionState _enemyAction;
    GameObject _firstMoveObj;
    GameObject _enemy;
    bool _isEnemyLook;                  //エネミーが範囲に入ったかを知らせるbool

    private void Awake()
    {
        _enemyAction = FindAnyObjectByType<EnemyActionState>();
        _firstMoveObj = GameObject.FindGameObjectWithTag("EnemyMovePoint");
        _enemy = GameObject.FindGameObjectWithTag("Enemy");
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, _enemy.transform.position) < 3) //敵エネミーとエネミーの距離が3より小さくなったら動きを止める
        {
            _enemyAction.ChangeSetMove(transform.position);
        }
        else if (Vector3.Distance(transform.position, _enemy.transform.position) <
                 15) //敵エネミーとエネミーの距離が15より小さくなったらエネミーの方向に移動する
        {
            _enemyAction.ChangeSetMove(_enemy.transform.position);
        }
    }
}