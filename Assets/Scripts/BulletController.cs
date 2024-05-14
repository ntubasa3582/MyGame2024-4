using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class BulletController : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 5;
    GameObject _player;
    Rigidbody _rb;
    Vector3 _bulletDirection;
    float _timer;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _bulletDirection = _player.transform.forward;
        _bulletDirection.y = 0;
    }
    
    void Update()
    {
        _rb.velocity = _bulletDirection * (_bulletSpeed * 50);
        _timer += Time.deltaTime;
        if (_timer > 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
