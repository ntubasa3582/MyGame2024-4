using UnityEngine;
using System.Collections;
using DG.Tweening;

public class EnemyAttack : MonoBehaviour        //エネミーの攻撃行動スクリプト
{
    [SerializeField] GameObject _rotateAttackObj;
    [SerializeField] float _delayValue;

    void Start()
    {
        _rotateAttackObj.SetActive(false);
    }

    public void RotateAttack()      //このメソッドが呼ばれたとき自身が回転して攻撃判定のあるオブジェクトのセットアクティブを切り替える
    {
        transform.DOLocalRotate(new Vector3(0, transform.localEulerAngles.y + 360f, 0), 0.3f,
            RotateMode.FastBeyond360);
        _rotateAttackObj.SetActive(true);
        StartCoroutine(DelayActiveChange(0.3f));
    }
    
    IEnumerator DelayActiveChange(float delayTime)
    {
        delayTime = _delayValue;
        yield return new WaitForSeconds(delayTime);
        _rotateAttackObj.SetActive(false);
    }
}
