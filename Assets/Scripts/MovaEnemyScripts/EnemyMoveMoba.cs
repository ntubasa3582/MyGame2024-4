using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class EnemyMoveMoba : MonoBehaviour
{
    GameObject _targetPos;     //移動地点を入れる変数
    [SerializeField] float _moveSpeed = 5;          //移動スピードを入れる変数
    [SerializeField] bool _isMove = true;
    NavMeshAgent _navMeshAgent;
    void Awake()
    {
        _targetPos = GameObject.FindGameObjectWithTag("EnemyMovePoint");
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetDestinationChange(Vector3 _targetVector)
    {
        Vector3 vector = _targetVector;
        _navMeshAgent.SetDestination(vector);
    }
}
