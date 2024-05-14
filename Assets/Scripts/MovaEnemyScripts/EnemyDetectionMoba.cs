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
        _enemyAction.ChangeSetMove(_targetObj.transform.position);                          //_targetObj�܂�Enemy�������悤�ɏ����𑗂�
    }
    
    
    void Update()
    {
        if (Vector3.Distance(transform.position, _enemy.transform.position) < 3)            //�G�l�~�[�Ƃ̋�����3�ɂȂ����瓮�����~�߂鏈���𑗂�
        {
            _enemyAction.ChangeSetMove(transform.position);
        }
        else if (Vector3.Distance(transform.position, _enemy.transform.position) < 15)      //�G�l�~�[�Ƃ̋�����15�ɂȂ�����G�l�~�[�̕����ɓ����������𑗂�
        {
            _enemyAction.ChangeSetMove(_enemy.transform.position);
        }
    }
}
