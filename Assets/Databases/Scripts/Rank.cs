using UnityEngine;

/// <summary>
/// 발키리의 랭크에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Rank : ScriptableObject
{
    #region 변수

    [Header("랭크")]
    [SerializeField] private RankID _rank_ID; // 식별자

    [Space(10), Header("아이콘")]
    [SerializeField] private Sprite _icon; // 아이콘

    #endregion 변수

    #region 프로퍼티

    public RankID Rank_ID
    {
        get { return _rank_ID; }
        set { _rank_ID = value; }
    }

    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    #endregion 프로퍼티
}

public enum RankID
{
    B, A, S, S1, S2, S3, SS, SS1, SS2, SS3, SSS
}