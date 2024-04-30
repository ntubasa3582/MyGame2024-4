using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [FormerlySerializedAs("_moveLimitObjects")] [SerializeField]
    GameObject[] _moveLimitObj;

    [SerializeField] GameObject _target;
    Vector3 _mouseVector;
    bool _moveLimit;

    void Update()
    {
        if (_moveLimitObj[0].transform.position.x > transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }

        else if (_moveLimitObj[0].transform.position.z > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
        }

        if (_moveLimitObj[1].transform.position.x < transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }

        else if (_moveLimitObj[1].transform.position.z < transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        }


        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            _mouseVector =
                new Vector3(Input.GetAxisRaw("Mouse X"), 0, Input.GetAxisRaw("Mouse Y")); //characterの移動処理
            transform.position += _mouseVector * 0.03f;
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        if (Input.GetButton("Jump"))
        {
            transform.position =
                new Vector3(_target.transform.position.x, 10.56f, _target.transform.position.z + -8.5f);
        }
    }
}