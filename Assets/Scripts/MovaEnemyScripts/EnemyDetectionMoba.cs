using System.Collections;
using UnityEngine;

public class EnemyDetectionMoba : MonoBehaviour //エネミーと他オブジェクトの距離を管理するスクリプト
{
    EnemyActionState _enemyAction;
    EnemyTargetMoba _enemyTarget;
    GameObject _firstMoveObj; //最初の目標地点
    GameObject _targetEnemy; //近くにいるエネミーを入れる

    /// <summary>エネミーが範囲に入ったらTrue</summary>
    bool _rangeDetection;


    private void Awake()
    {
        _enemyAction = GetComponent<EnemyActionState>();
        _enemyTarget = GetComponent<EnemyTargetMoba>();
        _firstMoveObj = GameObject.FindGameObjectWithTag("EnemyMovePoint");
    }

    void Start()
    {
        _enemyTarget.TargetPositionChange(_firstMoveObj.transform.position);//目標地点の座標をEnemyActionに送る
        StartCoroutine(EnemySearch());          //近いエネミーを探す
    }


    void Update()
    {
        if (_targetEnemy != null)
        {
            if (Vector3.Distance(transform.position, _targetEnemy.transform.position) < 15) //敵エネミーとエネミーの距離が15より小さくなったらエネミーの方向に移動する
            {
                _enemyTarget.TargetPositionChange(_targetEnemy.transform.position);     //近い敵のポジションを_enemyTargetに送る
                _enemyTarget.TargetObjectChange(_targetEnemy);
            }
            if (Vector3.Distance(transform.position, _targetEnemy.transform.position) < 3) //敵エネミーとエネミーの距離が3より小さくなったら動きを止める
            {
                _enemyTarget.TargetPositionChange(transform.position);                  //自分の動きを止める
                _enemyTarget.TargetObjectChange(_targetEnemy);                          //近い敵のObj情報を_enemyTargetに送る
                _enemyAction.AttackSwitch(true);    //攻撃するかしないかを切り替える
                _rangeDetection = true;     //敵検知フラグをTrueにする
            }
            else
            {
                _enemyAction.AttackSwitch(false);   //攻撃するかしないかを切り替える
                _rangeDetection = false;    //敵検知フラグをFalseにする
            }
        }
    }

    IEnumerator EnemySearch()       //1.5秒毎に一番近い敵を探す
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            _targetEnemy = GameObject.FindGameObjectWithTag("Enemy2");
        }
    }
}