using UnityEngine;

/// <summary>
/// 발키리가 가지는 속성에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class EntityType : ScriptableObject
{
    [Header("식별자")]
    public string _type_ID; // 식별자
    public string _name; // 이름

    [Space(10), Header("상성")]
    public EntityType _advantage; // 상성
    public EntityType _disadvantage; // 역상성

    [Space(10), Header("아이콘")]
    public Sprite iconSprite; // 아이콘 이미지
}