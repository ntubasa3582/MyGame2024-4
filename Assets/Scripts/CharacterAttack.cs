using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class CharacterAttack : MonoBehaviour
{
    [FormerlySerializedAs("_RotateAttackObjects")] [FormerlySerializedAs("_attackObjects")] [SerializeField] GameObject[] _rotateAttackObjects;
    [SerializeField] GameObject _rotateAttackObj;
    bool _continuousAttack;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!_continuousAttack)
            {
                //自身が回転する
                transform.DOLocalRotate(new Vector3(0, transform.localEulerAngles.y + 360f, 0), 0.3f,
                    RotateMode.FastBeyond360);
                _continuousAttack = true;
                _rotateAttackObj.SetActive(true);
                StartCoroutine(DelayActiveChange(0.3f));
            }
        }
        
        //
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     if (_rotateAttackObjects != null)
        //     {
        //         for (int i = 0; i < _rotateAttackObjects.Length; i++)
        //         {
        //             Instantiate(_rotateAttackObjects[i], transform.position, Quaternion.identity);   //自身の周りを回転するオブジェクトを生成する
        //         }   
        //     }
        // }
        //
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     
        // }
    }

    IEnumerator DelayActiveChange(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _rotateAttackObj.SetActive(false);
        _continuousAttack = false;
    }
}