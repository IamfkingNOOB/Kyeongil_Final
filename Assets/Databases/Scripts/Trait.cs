using UnityEngine;

/// <summary>
/// 발키리가 가지는 특성에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class Trait : ScriptableObject
{
    #region 변수

    [Header("식별자")]
    [SerializeField] private TraitID _trait_ID; // 식별자
    [SerializeField] private string _name; // 이름

    [Space(10), Header("설명"), TextArea]
    [SerializeField] private string _description; // 설명문

    [Space(10), Header("아이콘")]
    [SerializeField] private Sprite _icon; // 아이콘

    #endregion 변수

    #region 프로퍼티

    public TraitID Trait_ID
    {
        get { return _trait_ID; }
        set { _trait_ID = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
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

public enum TraitID
{
    PHYSICAL, // 물리
    FIRE_DMG, // 화염 대미지
    ICE_DMG, // 빙결 대미지
    LIGHTNING_DMG, // 뇌전 대미지
    FREEZE, // 빙결
    PARALYZE, // 마비
    STUN, // 기절
    IGNITE, // 점화
    BLEED, // 출혈
    HEAVY_ATK, // 강타
    WEAKEN, // 허약
    IMPAIR, // 취약
    TIME_MASTERY, // 시공
    GATHER, // 흡인
    HEAL, // 치료
    FAST_ATK, // 높은 빈도
    BURST, // 폭발, 버스트
    AERIAL // 대공
}