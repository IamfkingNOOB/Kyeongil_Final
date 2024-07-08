using UnityEngine;

/// <summary>
/// 발키리(캐릭터)에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Valkyrie : ScriptableObject
{
    #region 변수

    [Header("식별자")]
    [SerializeField] private int _valkyrie_ID; // 식별자
    [SerializeField] private string _characterName; // 캐릭터 이름
    [SerializeField] private string _suitName; // 슈트 이름

    [Space(10), Header("속성")]
    [SerializeField] private EntityType _type; // 속성
    [SerializeField] private Trait[] _traits; // 특성

    [Space(10), Header("스탯 (플레이어)")]
    [SerializeField] private Rank _rank; // 랭크
    [SerializeField] private int _level; // 레벨

    [Space(10), Header("스탯 (발키리)")]
    [SerializeField] private int _hp; // 체력
    [SerializeField] private int _sp; // SP(스킬 포인트)
    [SerializeField] private int _atk; // 공격력
    [SerializeField] private int _def; // 방어력
    [SerializeField] private int _crt; // 회심

    [Space(10), Header("장비")]
    [SerializeField] private Weapon _weapon; // 무기
    [SerializeField] private Stigmata _stigmata_T; // 성흔 (상)
    [SerializeField] private Stigmata _stigmata_M; // 성흔 (중)
    [SerializeField] private Stigmata _stigmata_B; // 성흔 (하)

    [Space(10), Header("스킬")]
    [SerializeField] private Skill _leaderSkill; // 리더 스킬
    [SerializeField] private Skill _passive; // 패시브
    [SerializeField] private Skill _evasion; // 회피
    [SerializeField] private Skill _weaponSkill; // 무기 스킬
    [SerializeField] private Skill _basicATK; // 기본 공격
    [SerializeField] private Skill _ultimate; // 필살기
    [SerializeField] private Skill _specialATK; // 특수 공격

    [Space(10), Header("설명"), TextArea]
    [SerializeField] private string _description; // 설명문

    [Space(10), Header("모델")]
    [SerializeField] private Sprite _portrait; // 초상화
    [SerializeField] private GameObject _model; // 모델

    #endregion 변수

    #region 프로퍼티

    public int Valkyrie_ID
    {
        get { return _valkyrie_ID; }
        set { _valkyrie_ID = value; }
    }

    public string CharacterName
    {
        get { return _characterName; }
        set { _characterName = value; }
    }

    public string SuitName
    {
        get { return _suitName; }
        set { _suitName = value; }
    }

    public EntityType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public Trait[] Traits
    {
        get { return _traits; }
        set { _traits = value; }
    }

    public Rank Rank
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

    public Weapon Weapon
    {
        get { return _weapon; }
        set { _weapon = value; }
    }

    public Stigmata Stigmata_T
    {
        get { return _stigmata_T; }
        set { _stigmata_T = value; }
    }

    public Stigmata Stigmata_M
    {
        get { return _stigmata_M; }
        set { _stigmata_M = value; }
    }

    public Stigmata Stigmata_B
    {
        get { return _stigmata_B; }
        set { _stigmata_B = value; }
    }

    public Skill LeaderSkill
    {
        get { return _leaderSkill; }
        set { _leaderSkill = value; }
    }

    public Skill Passive
    {
        get { return _passive; }
        set { _passive = value; }
    }

    public Skill Evasion
    {
        get { return _evasion; }
        set { _evasion = value; }
    }

    public Skill WeaponSkill
    {
        get { return _weaponSkill; }
        set { _weaponSkill = value; }
    }

    public Skill BasicATK
    {
        get { return _basicATK; }
        set { _basicATK = value; }
    }

    public Skill Ultimate
    {
        get { return _ultimate; }
        set { _ultimate = value; }
    }

    public Skill SpecialATK
    {
        get { return _specialATK; }
        set { _specialATK = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public Sprite Portrait
    {
        get { return _portrait; }
        set { _portrait = value; }
    }

    public GameObject Model
    {
        get { return _model; }
        set { _model = value; }
    }

    #endregion 프로퍼티
}