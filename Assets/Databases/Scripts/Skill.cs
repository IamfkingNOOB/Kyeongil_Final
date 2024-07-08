using UnityEngine;

/// <summary>
/// 발키리 및 무기가 가지는 스킬에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Skill : ScriptableObject
{
    #region 변수

    [Header("식별자")]
    [SerializeField] private string _skill_ID; // 식별자
    [SerializeField] private string _name; // 이름

    [Space(10), Header("종류")]
    [SerializeField] private SkillType _type; // 종류

    [Space(10), Header("스탯")]
    [SerializeField] private int _sp; // SP 소모량
    [SerializeField] private int _cd; // 재사용 대기시간

    [Space(10), Header("수치")]
    [SerializeField] private float[] _values; // 대미지 등의 수치 값 목록

    [Space(10), Header("설명"), TextArea]
    [SerializeField] private string _description; // 설명문

    [Space(10), Header("아이콘")]
    [SerializeField] private Sprite _icon; // 아이콘

    #endregion 변수

    #region 프로퍼티

    public string Skill_ID
    {
        get { return _skill_ID; }
        set { _skill_ID = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public SkillType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public int SP
    {
        get { return _sp; }
        set { _sp = value; }
    }

    public int CD
    {
        get { return _cd; }
        set { _cd = value; }
    }

    public float[] Values
    {
        get { return _values; }
        set { _values = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    #endregion 프로퍼티
}

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