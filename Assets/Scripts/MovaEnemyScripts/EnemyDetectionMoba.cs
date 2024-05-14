using UnityEngine;
using UnityEngine.Serialization;

public class EnemyDetectionMoba : MonoBehaviour
{
    EnemyActionMoba _enemyAction;

    [SerializeField] GameObject _targetObj;
    GameObject _enemy;

    private void Awake()
    {
        _enemyAction = FindAnyObjectByType<EnemyActionMoba>();
        _targetObj = GameObject.FindGameObjectWithTag("EnemyMovePoint");
        _enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Start()
    {
        _enemyAction.ChangeSetMove(_targetObj.transform.position);                          //_targetObjまでEnemyが動くように処理を送る
    }
    
    
    void Update()
    {
        if (Vector3.Distance(transform.position, _enemy.transform.position) < 3)            //エネミーとの距離が3になったら動きを止める処理を送る
        {
            _enemyAction.ChangeSetMove(transform.position);
        }
        else if (Vector3.Distance(transform.position, _enemy.transform.position) < 15)      //エネミーとの距離が15になったらエネミーの方向に動かす処理を送る
        {
            _enemyAction.ChangeSetMove(_enemy.transform.position);
        }
    }
}
