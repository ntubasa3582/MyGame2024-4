using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 _mouseVector;

    void Update()
    {
        if (Input.GetMouseButton(1)&&!Input.GetMouseButton(0))
        {
            _mouseVector = new Vector3(Input.GetAxisRaw("Mouse X"),0, Input.GetAxisRaw("Mouse Y")); //characterの移動処理
            transform.position += _mouseVector*0.03f;
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}