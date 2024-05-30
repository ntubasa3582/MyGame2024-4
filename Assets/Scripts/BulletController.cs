using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [SerializeField] float _bulletSpeed; //弾の移動パラメータ
    [SerializeField] float _deathCount = 1.5f; //自身がデストロイするまでの時間
    EnemyTargetMoba _enemyTarget;
    Transform _transform;
    GameObject _attackTarget;
    float _deathTimer; //毎フレーム数値を入れる変数

    void Awake()
    {
        _enemyTarget = GameObject.FindAnyObjectByType<EnemyTargetMoba>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _deathTimer += Time.deltaTime;
        if (_deathTimer > _deathCount)
        {
            Destroy(gameObject);
        }

        _attackTarget = _enemyTarget.TargetObj;
        _transform.position = Vector3.MoveTowards(transform.position, _attackTarget.transform.position, _bulletSpeed);
    }


    void OnTriggerEnter(Collider other)
    {
        //当たり判定のあるオブジェクトに触れたら自身をデストロイする
        if (other.gameObject.CompareTag("Enemy2"))
        {
            Destroy(gameObject);
        }
    }
}