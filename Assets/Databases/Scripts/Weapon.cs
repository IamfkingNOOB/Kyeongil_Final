using UnityEngine;

/// <summary>
/// 무기에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    #region 변수

    [Header("식별자")]
    [SerializeField] private string _weapon_ID; // 식별자
    [SerializeField] private WeaponType _type; // 종류
    [SerializeField] private string _name; // 이름

    [Space(10), Header("스탯 (플레이어)")]
    [SerializeField] private int _rank; // 랭크
    [SerializeField] private int _level; // 레벨

    [Space(10), Header("스탯 (무기)")]
    [SerializeField] private int _atk; // 공격력
    [SerializeField] private int _crt; // 회심

    [Space(10), Header("스킬")]
    [SerializeField] private Skill[] _skills; // 무기 스킬

    [Space(10), Header("설명"), TextArea]
    [SerializeField] private string _description; // 설명문

    [Space(10), Header("모델")]
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _model; // 프리팹 모델

    #endregion 변수

    #region 프로퍼티

    public string Weapon_ID
    {
        get { return _weapon_ID; }
        set { _weapon_ID = value; }
    }

    public WeaponType WeaponType
    {
        get { return _type; }
        set { _type = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
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

    public int ATK
    {
        get { return _atk; }
        set { _atk = value; }
    }

    public int CRT
    {
        get { return _crt; }
        set { _crt = value; }
    }

    public Skill[] Skills
    {
        get { return _skills; }
        set { _skills = value; }
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

    public GameObject Model
    {
        get { return _model; }
        set { _model = value; }
    }

    #endregion 프로퍼티
}

public enum WeaponType
{
    PISTOL, // 쌍권총
    BLADE, // 태도
    HEAVY, // 대포
    TWO_HANDED, // 대검
    CROSS, // 십자가
    FISTS, // 건틀릿
    SCYTHE, // 낫
    LANCE, // 랜스
    BOW, // 활
    CHAKRAM, // 차크람
    JAVLIN, // 재블린
}