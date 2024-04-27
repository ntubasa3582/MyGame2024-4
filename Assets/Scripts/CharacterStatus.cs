using UnityEngine;

[CreateAssetMenu(menuName = "CharacterStatus")]
public class CharacterStatus : ScriptableObject    //キャラクターのステータスを管理するスクリプト
{
    public float SpeedParameter;    //キャラクターの移動速度パラメータ
    public float CharacterHp;       //キャラクターのHPパラメータ
}