using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour        //プレイヤーの攻撃を制御スクリプト
{
    [FormerlySerializedAs("_RotateAttackObjects")] [FormerlySerializedAs("_attackObjects")] [SerializeField] GameObject[] _rotateAttackObjects;
    [SerializeField] GameObject _rotateAttackObj;
    [FormerlySerializedAs("_playerBullet")] [SerializeField] GameObject _attackBullet;
    [SerializeField] float _bulletSpeed;
    bool _continuousAttack;     //攻撃時のクールダウンフラグ
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(transform.forward);
            //_attackBullet生成   bulletに_attackBulletを入れる
            GameObject bullet = Instantiate(_attackBullet, this.transform.position, Quaternion.identity);
            //のRigidbodyを取得  
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(this.transform.forward * _bulletSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!_continuousAttack)
            {
                transform.DOLocalRotate(new Vector3(0, transform.localEulerAngles.y + 360f, 0), 0.3f,RotateMode.FastBeyond360);     //rotation.y360度回転する
                _continuousAttack = true;
                _rotateAttackObj.SetActive(true);       //攻撃タグがついているオブジェクトのセットアクティブをオンにする
                StartCoroutine(DelayActiveChange(0.3f));
            }
        }
    }

    IEnumerator DelayActiveChange(float delayTime)      //ディレイをかけて攻撃判定のあるオブジェクトのセットアクティブをオフにする
    {
        yield return new WaitForSeconds(delayTime);
        _rotateAttackObj.SetActive(false);
        _continuousAttack = false;      //クールダウンフラグをオフにする
    }
}