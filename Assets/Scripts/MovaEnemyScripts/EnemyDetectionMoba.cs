using System.Collections;
using UnityEngine;

public class EnemyDetectionMoba : MonoBehaviour //エネミーと他オブジェクトの距離を管理するスクリプト
{
    EnemyActionState _enemyAction;
    GameObject _firstMoveObj; //最初の目標地点
    GameObject _targetEnemy; //近くにいるエネミーを入れる

    /// <summary>エネミーが範囲に入ったらTrue</summary>
    bool _rangeDetection;

    public bool RangeDetection
    {
        get { return _rangeDetection; }
        set { _rangeDetection = value; }
    }


    private void Awake()
    {
        _enemyAction = FindAnyObjectByType<EnemyActionState>();
        _firstMoveObj = GameObject.FindGameObjectWithTag("EnemyMovePoint");
    }

    void Start()
    {
        _enemyAction.ChangeSetMove(_firstMoveObj.transform.position); //目標地点の座標をEnemyActionに送る
        StartCoroutine(EnemySearch());          //近いエネミーを探す
    }


    void Update()
    {
        if (_targetEnemy != null)
        {
            if (Vector3.Distance(transform.position, _targetEnemy.transform.position) < 15) //敵エネミーとエネミーの距離が15より小さくなったらエネミーの方向に移動する
            {
                _enemyAction.ChangeSetMove(_targetEnemy.transform.position);
            }
            if (Vector3.Distance(transform.position, _targetEnemy.transform.position) < 3) //敵エネミーとエネミーの距離が3より小さくなったら動きを止める
            {
                _enemyAction.ChangeSetMove(transform.position);
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
            _targetEnemy = GameObject.FindGameObjectWithTag("Enemy");
        }
    }
}