using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 발키리(캐릭터)에 대한 데이터
/// </summary>
public class Valkyrie
{
    // 식별자
    public int ValkyrieID { get; set; } // 식별자
    public string CharacterName { get; set; } // 캐릭터 이름
    public string SuitName { get; set; } // 슈트 이름

    // 속성
    public EntityType Type { get; set; } // 속성
    public List<ValkyrieTrait> Traits { get; set; } // 특성

    // 스탯 (플레이어)
    public int RankID { get; set; } // 랭크
    public int Level { get; set; } // 레벨

    // 스탯 (발키리)
    public int HP { get; set; } // 체력
    public int SP { get; set; } // SP(스킬 포인트)
    public int ATK { get; set; } // 공격력
    public int DEF { get; set; } // 방어력
    public int CRT { get; set; } // 회심

    // 장비
    public WeaponType EquipableWeaponType { get; set; } // 장착 가능한 무기 종류
    public Weapon WeaponID { get; set; } // 무기
    public Stigmata StigmataTopID { get; set; } // 성흔 (상)
    public Stigmata StigmataMiddleID { get; set; } // 성흔 (중)
    public Stigmata StigmataBottomID { get; set; } // 성흔 (하)

    // 스킬
    public string LeaderSkill { get; set; } // 리더 스킬
    public string Passive { get; set; } // 패시브
    public string Evasion { get; set; } // 회피
    public string WeaponSkill { get; set; } // 무기 스킬
    public string BasicATK { get; set; } // 기본 공격
    public string Ultimate { get; set; } // 필살기
    public string SpecialATK { get; set; } // 특수 공격

    // 설명
    public string Description { get; set; } // 설명문

    // 모델
    public Sprite Portrait { get; set; } // 초상화
    public GameObject Model { get; set; } // 모델
}

public enum EntityType
{
    BIOLOGY, // 생물
    PSYCHIC, // 이능
    MECHA, // 기계
    QUANTUM, // 양자
    IMAGINARY, // 허수
    STARDUST // 성진
}

public enum ValkyrieTrait
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
