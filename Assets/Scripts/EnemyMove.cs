using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour          //エネミーの移動を制御するスクリプト
{
    EnemyAttack _enemyAttack;                   //エネミーの攻撃スクリプト
    NavMeshAgent _navMeshAgent;
    [SerializeField,Header("移動スピード")] float _speedParameter;     //移動スピードパラメータ
    [SerializeField,Header("追跡範囲")] float _detectionRange = 5;    //targetの追跡範囲
    GameObject _target;                         //追いかける対象を入れる変数
    float _attackTimer;                         //攻撃時のタイマーの値を入れる変数
    bool _playerDetection;                      //プレイヤーを見つけたかの判定をとる変数

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _enemyAttack = GetComponent<EnemyAttack>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _speedParameter;
    }

    void Update()
    {
    }
    void MoveAction()       //主な動きを管理するメソッド
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < _detectionRange)       //_targetが_detectionRangeに入ったら自身に向かってくる
        {
            _playerDetection = true;
            _attackTimer += Time.deltaTime;
            if (_attackTimer > 3)
            {
                _enemyAttack.RotateAttack();
                _attackTimer = 0;
            }
            TargetMove(_target.transform.position);
        }
        else
        {
            TargetMove(transform.position);
            _playerDetection = false;
            _attackTimer = 0;                                           //範囲外に出たらタイマーを０にする
        }
        if (_playerDetection)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) < 2f)    //追跡範囲に入っているときに距離が近くなったら攻撃する
            {
                TargetMove(transform.position);
            }
        }
    }

    void TargetMove(Vector3 targetVector)       //_navMeshAgentを使って動かすメソッド
    {
        _navMeshAgent.SetDestination(targetVector);   //SetDestinationに_targetの座標を入れる
        transform.LookAt(targetVector);               //targetの方向を向く
    }

    void OnTriggerEnter(Collider other)
    {
        //攻撃判定のあるオブジェクトに触れたら自身をデストロイする
        if (other.gameObject.CompareTag("Attack"))
        {
            Destroy(gameObject);
        }
    }
}
