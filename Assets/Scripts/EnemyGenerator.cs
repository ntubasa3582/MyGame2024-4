using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour //エネミーの生成を管理するスクリプト
{
    [SerializeField] GameObject _enemies; //エネミーオブジェクトを入れる変数
    [SerializeField] GameObject[] _spawnPoints; //エネミーのスポーン場所を入れる変数
    [SerializeField,Tooltip("True触れたら沸く")] bool _spawnSwitch; //エネミーの生成方法を変更する変数

    /// <summary>エネミーを生成するメソッド</summary>
    public void EnemySpawn()
    {
        if (_spawnSwitch)
        {
            int num = Random.Range(0, 3);
            Instantiate(_enemies, _spawnPoints[num].transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (_spawnSwitch)
        {
            if (other.gameObject.CompareTag("Player")) //Playerタグのついたオブジェクトがコライダーに入ったときEnemyを生成
            {
                EnemySpawn();
            }
        }
    }
}