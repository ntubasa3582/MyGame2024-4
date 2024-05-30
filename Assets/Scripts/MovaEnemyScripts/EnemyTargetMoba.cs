using UnityEngine;

public class EnemyTargetMoba : MonoBehaviour
{
    GameObject _targetObj;
    Vector3 _targetPos;
    public GameObject TargetObj => _targetObj;
    public Vector3 TargetPos => _targetPos;
    /// <summary>ターゲットのオブジェクトを取得するメソッド</summary>
    /// <param name="targetObj">ターゲットを代入する変数</param>
    public void TargetObjectChange(GameObject targetObj)
    {
        _targetObj = targetObj;
    }
    /// <summary>ターゲットのポジションを取得するメソッド</summary>
    /// <param name="targetPos">ターゲットのポジションを代入する変数</param>
    public void TargetPositionChange(Vector3 targetPos)
    {
        _targetPos = targetPos;
    }
}
