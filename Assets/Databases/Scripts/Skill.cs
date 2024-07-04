using UnityEngine;

public enum SkillType
{
    // Valkyrie
    LEADER_SKILL,
    PASSIVE,
    EVASION,
    WEAPON_SKILL,
    BASIC_ATK,
    ULTIMATE,
    SPECIAL_ATK,

    // Weapon
    WEAPON_ACTIVE,
    WEAPON_PASSIVE,

    // Stigmata
    STIGMATA,
    STIGMATA_SET_02,
    STIGMATA_SET_03
}

/// <summary>
/// 발키리 및 무기가 가지는 스킬에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Skill : ScriptableObject
{
    [Header("식별자")]
    public string _skill_ID; // 식별자
    public string _name; // 이름

    [Space(10), Header("종류")]
    public SkillType _type; // 종류

    [Space(10), Header("스탯")]
    public int _sp; // SP 소모량
    public int _cd; // 재사용 대기시간

    [Space(10), Header("수치")]
    public float[] _values; // 대미지 등의 수치 값 목록

    [Space(10), Header("설명"), TextArea]
    public string _description; // 설명문

    [Space(10), Header("아이콘")]
    public Sprite _iconSprite; // 아이콘 이미지
}