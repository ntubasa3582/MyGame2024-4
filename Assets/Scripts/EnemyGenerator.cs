using UnityEngine;

public class EnemyGenerator : MonoBehaviour     //エネミーの生成を管理するスクリプト
{
    [SerializeField] GameObject _enemies;         //エネミーオブジェクトを入れる変数
    [SerializeField] GameObject[] _spawnPoints;     //エネミーのスポーン場所を入れる変数
    

/// <summary>エネミーを生成するメソッド</summary>
/// <param name="enemiesCount"></param>
/// <param name="spawnPoint"></param>
    void EnemySpawn()
    {
        int num = Random.Range(0, 3);
        Instantiate(_enemies, _spawnPoints[num].transform.position, Quaternion.identity);
        num = default;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  //Playerタグのついたオブジェクトがコライダーに入ったときEnemyを生成
        {
            
            EnemySpawn();
        }
    }

    // int RandomValue(int x, int y)
    // {
    //     return ;;
    // }
}
