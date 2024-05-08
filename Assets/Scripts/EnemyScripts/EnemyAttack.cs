using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject _rotateAttackObj;

    void Start()
    {
        _rotateAttackObj.SetActive(false);
    }

    public void RotateAttack()
    {
        transform.DOLocalRotate(new Vector3(0, transform.localEulerAngles.y + 360f, 0), 0.3f,
            RotateMode.FastBeyond360);
        _rotateAttackObj.SetActive(true);
        StartCoroutine(DelayActiveChange(0.3f));
    }
    
    IEnumerator DelayActiveChange(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _rotateAttackObj.SetActive(false);
    }
}
