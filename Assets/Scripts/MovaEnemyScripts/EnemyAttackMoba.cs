using UnityEngine;

public class EnemyAttackMoba : MonoBehaviour
{
    [SerializeField] GameObject _enemyBullet;       //敵が発射する弾
    
    void Start()
         {
             
         }
     
         void Update()
         {
             
         }

         public void CasterAttack()      //遠距離攻撃
         {
             Instantiate(_enemyBullet, transform.position, Quaternion.identity);
         }

         public void MeleeAtack()       //近距離攻撃
         {
             
         }       
}
