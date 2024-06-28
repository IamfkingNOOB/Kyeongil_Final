using UnityEngine;

public enum ValkyrieName
{
    THERESA_C7,
}

public enum Weapon { }
public enum Stigma { }

/// <summary>
/// 캐릭터의 전반적인 정보를 다루는 클래스입니다.
/// </summary>
public class BaseCharacterInfo : MonoBehaviour
{
    [Header("Character Infos")]
    [SerializeField] private ValkyrieName _characterName;
    [SerializeField] private int _healthPoint;
    [SerializeField] private int _skillPoint;
    [SerializeField] private int _atkPoint;
    [SerializeField] private int _dfnPoint;
    [SerializeField] private int _crtPoint;

    [Header("Character Equipments")]
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Stigma _stigma01;
    [SerializeField] private Stigma _stigma02;
    [SerializeField] private Stigma _stigma03;

    // 스킬과 관련하여, DataDriven 기술을 사용해 보자.


}
