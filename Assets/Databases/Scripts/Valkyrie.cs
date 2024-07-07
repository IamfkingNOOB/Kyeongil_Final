using UnityEngine;

/// <summary>
/// 발키리(캐릭터)에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Valkyrie : ScriptableObject
{
    [Header("식별자")]
    public int _valkyrie_ID; // 식별자
    public string _name; // 이름

    [Space(10), Header("속성")]
    public EntityType _type; // 속성
    public ValkyrieTrait[] _traits; // 특성

    [Space(10), Header("스탯 (플레이어)")]
    public string _rank; // 랭크
    public int _level; // 레벨

    [Space(10), Header("스탯 (발키리)")]
    public int _hp; // 체력
    public int _sp; // SP(스킬 포인트)
    public int _atk; // 공격력
    public int _def; // 방어력
    public int _crt; // 회심

    [Space(10), Header("장비")]
    public Weapon _weapon; // 무기
    public Stigmata _stigmata_T; // 성흔 (상)
    public Stigmata _stigmata_M; // 성흔 (중)
    public Stigmata _stigmata_B; // 성흔 (하)

    [Space(10), Header("스킬")]
    public Skill _leaderSkill; // 리더 스킬
    public Skill _passive; // 패시브
    public Skill _evasion; // 회피
    public Skill _weaponSkill; // 무기 스킬
    public Skill _basic_ATK; // 기본 공격
    public Skill _ultimate; // 필살기
    public Skill _special_Attack; // 특수 공격

    [Space(10), Header("설명"), TextArea]
    public string _description; // 설명문

    [Space(10), Header("모델")]
    public GameObject _prefabModel; // 프리팹 모델
}