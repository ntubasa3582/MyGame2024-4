using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    EnemyAttack _enemyAttack;
    [SerializeField] float _speedParameter;
    GameObject _target;
    float _playerDistance;
    float _moveSpeed;
    float _timer;
    bool _playerDetection;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Character");
        _enemyAttack = GetComponent<EnemyAttack>();
    }

    void Update()
    {
        
        if (Vector3.Distance(transform.position, _target.transform.position) < 5)
        {
            _playerDetection = true;
            _timer += Time.deltaTime;
        }
        else
        {
            _playerDetection = false;
            _timer = 0;
        }
        if (_playerDetection)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) > 2.5f)
            {
                _moveSpeed = _speedParameter * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _moveSpeed);
                transform.LookAt(_target.transform.position);
            }
            else
            {
                transform.LookAt(_target.transform.position);
                if (_timer > 3)
                {
                    _enemyAttack.RotateAttack();
                    _timer = 0;
                }
            }
        }
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
