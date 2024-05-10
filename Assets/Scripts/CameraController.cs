using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour //カメラの移動制御スクリプト
{
    Camera _mainCamera;
    [FormerlySerializedAs("_moveLimitObj")] [SerializeField] GameObject[] _limitObj; //カメラの移動の制限座標のオブジェクト
    GameObject _target; //カメラが正面に移すオブジェクト
    [SerializeField] float _cameraSpeed; //カメラスピード
    Vector3 _moveLimit;
    Vector3 _mouseVector; //マウスの座標の変数
    float _mouseScrollValue; //マウスホイールの入力時の値を入れる変数

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(_target.transform.position.x, 15f, _target.transform.position.z + -7.5f);
        _mainCamera = Camera.main;
    }
    

    void Update()
    {
        if (_mainCamera.fieldOfView > 35 &&
            _mainCamera.fieldOfView < 100) //35から100までの値を超えていなかったら_mainCamera.fieldOfViewの値を変える
        {
            _mouseScrollValue = -1 * Input.mouseScrollDelta.y; //マウスホイールの入力値を変数に入れる    -1をかけて値を逆にする
            _mainCamera.fieldOfView += _mouseScrollValue;
        }
        else if (_mainCamera.fieldOfView < 35) //35より下の場合35.1にする
        {
            _mainCamera.fieldOfView = 35.1f;
        }
        else if (_mainCamera.fieldOfView > 100) //100より上に場合99.9にする
        {
            _mainCamera.fieldOfView = 99.9f;
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,_limitObj[1].transform.position.x,_limitObj[0].transform.position.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z,_limitObj[1].transform.position.x,_limitObj[0].transform.position.z)
        );

        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0)) //左クリックでカメラの移動
        {
            _mouseVector =
                new Vector3(Input.GetAxisRaw("Mouse X"), 0, Input.GetAxisRaw("Mouse Y")); //マウスの移動量を変数に代入する
            transform.position += _mouseVector * _cameraSpeed; //移動量にTime.deltaTimeをかけてtransformに代入する
            Cursor.visible = false; //マウスカーソルの表示をオフにする
        }
        else
        {
            Cursor.visible = true; //マウスカーソルの表示をオンにする
        }

        if (Input.GetButton("Jump")) //Spaceキーが押されたらtargetの位置にカメラを固定する
        {
            transform.position =
                new Vector3(_target.transform.position.x, 15f, _target.transform.position.z + -7.5f);
        }
    }
}