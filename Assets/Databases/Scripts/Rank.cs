using UnityEngine;

public enum RankStat
{
    B, A, S, S1, S2, S3, SS, SS1, SS2, SS3, SSS
}

/// <summary>
/// 발키리의 랭크에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Rank : ScriptableObject
{
    [Header("랭크")]
    public RankStat _rankStat;

    [Space(10), Header("아이콘")]
    public Sprite _iconSprite;
}