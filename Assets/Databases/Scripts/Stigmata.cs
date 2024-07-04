using UnityEngine;

public enum StigmataPosition
{
    TOP,
    MIDDLE,
    BOTTOM
}

/// <summary>
/// 성흔에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Stigmata : ScriptableObject
{
    [Header("식별자")]
    public string Stigmata_ID;
    public string Name;

    [Space(10), Header("부위")]
    public StigmataPosition Position;

    [Space(10), Header("스탯 (플레이어)")]
    public int Rank;
    public int Level;

    [Space(10), Header("스탯 (성흔)")]
    public int HP;
    public int SP;
    public int ATK;
    public int DEF;
    public int CRT;

    [Space(10), Header("스킬")]
    public Skill Skill;
    public Skill SetBonuses_2Set;
    public Skill SetBonuses_3Set;
}