using UnityEngine;

/// <summary>
/// 발키리가 가지는 특성에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class ValkyrieTrait : ScriptableObject
{
    [Header("식별자")]
    public string _trait_ID; // 식별자
    public string _name; // 이름

    [Space(10), Header("설명"), TextArea]
    public string _description; // 설명문

    [Space(10), Header("아이콘")]
    public Sprite _iconSprite; // 아이콘 이미지
}