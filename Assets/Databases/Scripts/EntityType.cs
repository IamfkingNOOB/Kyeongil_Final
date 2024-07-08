using UnityEngine;

/// <summary>
/// 개체(발키리, 몬스터)가 가지는 속성에 대한 데이터
/// </summary>
[CreateAssetMenu]
public class EntityType : ScriptableObject
{
    #region 변수

    [Header("식별자")]
    [SerializeField] private EntityTypeID _type_ID; // 식별자
    [SerializeField] private string _name; // 이름

    [Space(10), Header("상성")]
    [SerializeField] private EntityType _advantage; // 상성
    [SerializeField] private EntityType _disadvantage; // 역상성

    [Space(10), Header("아이콘")]
    [SerializeField] private Sprite _icon; // 아이콘

    #endregion 변수

    #region 프로퍼티

    public EntityTypeID Type_ID
    {
        get { return _type_ID; }
        set { _type_ID = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public EntityType Advantage
    {
        get { return _advantage; }
        set { _advantage = value; }
    }

    public EntityType Disadvantage
    {
        get { return _disadvantage; }
        set { _disadvantage = value; }
    }

    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    #endregion 프로퍼티
}

public enum EntityTypeID
{
    BIOLOGY, // 생물
    PSYCHIC, // 이능
    MECHA, // 기계
    QUANTUM, // 양자
    IMAGINARY, // 허수
    STARDUST // 성진
}