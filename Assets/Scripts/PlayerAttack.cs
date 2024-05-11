using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour //プレイヤーの攻撃を制御スクリプト
{
    [FormerlySerializedAs("_RotateAttackObjects")] [FormerlySerializedAs("_attackObjects")] [SerializeField]
    GameObject[] _rotateAttackObjects;

    [SerializeField] GameObject _rotateAttackObj;

    [FormerlySerializedAs("_playerBullet")] [SerializeField]
    GameObject _attackBullet;

    [SerializeField] float _bulletSpeed;
    bool _continuousAttack; //攻撃時のクールダウンフラグ

    void Update()
    {
        if (!_continuousAttack)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //_attackBullet生成   bulletに_attackBulletを入れる
                Instantiate(_attackBullet, this.transform.position, Quaternion.identity); //弾を生成
                _continuousAttack = true;
                StartCoroutine(DelayActiveChange(1.5f));
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.DOLocalRotate(new Vector3(0, transform.localEulerAngles.y + 360f, 0), 0.3f,
                    RotateMode.FastBeyond360); //rotation.y360度回転する
                _continuousAttack = true;
                _rotateAttackObj.SetActive(true); //攻撃タグがついているオブジェクトのセットアクティブをオンにする
                StartCoroutine(DelayActiveChange(0.5f));
            }
        }
    }

    IEnumerator DelayActiveChange(float delayTime) //ディレイをかけて攻撃判定のあるオブジェクトのセットアクティブをオフにする
    {
        yield return new WaitForSeconds(delayTime);
        _rotateAttackObj.SetActive(false);
        _continuousAttack = false; //クールダウンフラグをオフにする
    }
}