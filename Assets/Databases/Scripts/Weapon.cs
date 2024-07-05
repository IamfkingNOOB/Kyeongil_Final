using UnityEngine;

/// <summary>
/// 무기에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    [Header("식별자")]
    public string _weapon_ID; // 식별자
    public string _name; // 이름

    [Space(10), Header("스탯 (플레이어)")]
    public int _rank; // 랭크
    public int _level; // 레벨

    [Space(10), Header("스탯 (무기)")]
    public int _atk; // 공격력
    public int _crt; // 회심

    [Space(10), Header("스킬")]
    public Skill[] _skills; // 무기 스킬

    [Space(10), Header("설명"), TextArea]
    public string _description; // 설명문

    [Space(10), Header("모델")]
    public GameObject _weaponPrefab; // 프리팹 모델
}