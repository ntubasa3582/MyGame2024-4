using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class EnemyMoveMoba : MonoBehaviour          //エネミーの移動を管理するスクリプト
{
    [SerializeField] float _moveSpeed = 5;          //移動スピードを入れる変数
    [SerializeField] bool _isMove = true;
    NavMeshAgent _navMeshAgent;
    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetDestinationChange(Vector3 targetVector)
    {
        Vector3 vector = targetVector;
        _navMeshAgent.SetDestination(vector);
    }
}
