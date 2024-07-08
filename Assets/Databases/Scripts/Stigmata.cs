using UnityEngine;

/// <summary>
/// 성흔에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Stigmata : ScriptableObject
{
    #region 변수

    [Header("식별자")]
    [SerializeField] private string _stigmata_ID; // 식별자
    [SerializeField] private string _name; // 이름

    [Space(10), Header("부위")]
    [SerializeField] private StigmataPosition _position; // 부위 (상 / 중 / 하)

    [Space(10), Header("스탯 (플레이어)")]
    [SerializeField] private int _rank; // 랭크
    [SerializeField] private int _level; // 레벨

    [Space(10), Header("스탯 (성흔)")]
    [SerializeField] private int _hp; // 체력
    [SerializeField] private int _sp; // SP(스킬 포인트)
    [SerializeField] private int _atk; // 공격력
    [SerializeField] private int _def; // 방어력
    [SerializeField] private int _crt; // 회심

    [Space(10), Header("스킬")]
    [SerializeField] private Skill _skill; // 스킬
    [SerializeField] private Skill _set2; // 스킬 2 세트
    [SerializeField] private Skill _set3; // 스킬 3 세트

    [Space(10), Header("모델")]
    [SerializeField] private Sprite _icon; // 아이콘
    [SerializeField] private Sprite _model; // 모델

    #endregion 변수

    #region 프로퍼티

    public string Stigmata_ID
    {
        get { return _stigmata_ID; }
        set { _stigmata_ID = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public StigmataPosition Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public int Rank
    {
        get { return _rank; }
        set { _rank = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public int SP
    {
        get { return _sp; }
        set { _sp = value; }
    }

    public int ATK
    {
        get { return _atk; }
        set { _atk = value; }
    }

    public int DEF
    {
        get { return _def; }
        set { _def = value; }
    }

    public int CRT
    {
        get { return _crt; }
        set { _crt = value; }
    }

    public Skill Skill
    {
        get { return _skill; }
        set { _skill = value; }
    }

    public Skill Set2
    {
        get { return _set2; }
        set { _set2 = value; }
    }

    public Skill Set3
    {
        get { return _set3; }
        set { _set3 = value; }
    }

    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    public Sprite Model
    {
        get { return _model; }
        set { _model = value; }
    }

    #endregion 프로퍼티
}

public enum StigmataPosition
{
    TOP,
    MIDDLE,
    BOTTOM
}