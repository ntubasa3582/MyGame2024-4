using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class EnemyMoveMoba : MonoBehaviour          //エネミーの移動を管理するスクリプト
{
    EnemyTargetMoba _enemyTarget;
    [SerializeField] float _moveSpeed = 5;          //移動スピードを入れる変数
    NavMeshAgent _navMeshAgent;
    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyTarget = GetComponent<EnemyTargetMoba>();
    }

    void Update()
    {
        _navMeshAgent.SetDestination(_enemyTarget.TargetPos);
    }
}
