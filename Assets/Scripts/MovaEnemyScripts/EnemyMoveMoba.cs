using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class EnemyMoveMoba : MonoBehaviour
{
    EnemyAction _enemyAction;
    GameObject _targetPos;     //移動地点を入れる変数
    [SerializeField] float _moveSpeed = 5;          //移動スピードを入れる変数
    [SerializeField] bool _isMove = true;
    NavMeshAgent _navMeshAgent;
    void Start()
    {
        _targetPos = GameObject.FindGameObjectWithTag("EnemyMovePoint");
        _enemyAction = GameObject.FindAnyObjectByType<EnemyAction>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(_targetPos.transform.position);
    }
    void Update()
    {
        if (_isMove)
        {
            SetDestinationChange(_targetPos.transform.position);
        }
        else
        {
            SetDestinationChange(transform.position);
        }
    }

    public void SetDestinationChange(Vector3 _targetVector)
    {
        _navMeshAgent.SetDestination(_targetVector);
    }
}
