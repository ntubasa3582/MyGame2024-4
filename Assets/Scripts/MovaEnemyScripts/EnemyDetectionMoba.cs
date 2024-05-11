using UnityEngine;

public class EnemyDetectionMoba : MonoBehaviour
{
    GameObject _targetObj;
    void Start()
    {
        _targetObj = GameObject.FindGameObjectWithTag("EnemyMovePoint");
    }
    
    
    void Update()
    {
        
    }
}
