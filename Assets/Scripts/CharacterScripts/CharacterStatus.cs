using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "CharacterStatus")]
public class CharacterStatus : ScriptableObject    //キャラクターのステータスを管理するスクリプト
{
    [FormerlySerializedAs("SpeedParameter")] public float _speedParameter;    //キャラクターの移動速度パラメータ
    [FormerlySerializedAs("CharacterHp")] public float _characterHp;       //キャラクターのHPパラメータ
}