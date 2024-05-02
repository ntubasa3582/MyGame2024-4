using UnityEngine;
using DG.Tweening;

public class CharacterAttack : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // transform.DOLocalRotate(new Vector3(0,  transform.localEulerAngles.y + 360f, 0), 0.3f, RotateMode.FastBeyond360);    //自身が回転する
        }
    }
}