using UnityEngine;
using DG.Tweening;

public class CharacterAttack : MonoBehaviour
{
    GameObject _attackObj;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.DOLocalRotate(new Vector3(0, transform.localEulerAngles.y + 360f, 0), 0.3f,
                RotateMode.FastBeyond360); //自身が回転する
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(_attackObj, transform.position, Quaternion.identity);   //自身の周りを回転するオブジェクトを生成する
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }
}