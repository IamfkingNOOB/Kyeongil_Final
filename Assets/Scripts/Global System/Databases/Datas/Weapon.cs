using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 무기에 대한 데이터
/// </summary>
public class Weapon
{
    // 식별자
    public int WeaponID { get; set; } // 식별자
    public string Name { get; set; } // 이름
    public WeaponType Type { get; set; } // 종류
    public string WeaponTypeLocalizedName { get; set; } // 종류의 이름(명칭)
    

    // 스탯 (플레이어)
    public int Rank { get; set; } // 랭크
    public int Level { get; set; } // 레벨

    // 스탯 (무기)
    public int ATK { get; set; } // 공격력
    public int CRT { get; set; } // 회심

    // 스킬
    public List<string> Skills { get; set; } = new(); // 무기 스킬

    // 설명
    public string Description { get; set; } // 설명문

    // 모델
    public Sprite Icon { get; set; }
    public GameObject Model { get; set; } // 프리팹 모델

    private string GetTypeLocalizedName(WeaponType type)
    {
        string localizedName = string.Empty;

        switch (type)
        {
            case WeaponType.PISTOL:
                localizedName = "쌍권총";
                break;
            case WeaponType.BLADE:
                localizedName = "태도";
                break;
            case WeaponType.HEAVY:
                localizedName = "대포";
                break;
            case WeaponType.TWO_HANDED:
                localizedName = "대검";
                break;
            case WeaponType.CROSS:
                localizedName = "십자가";
                break;
            case WeaponType.FISTS:
                localizedName = "건틀릿";
                break;
            case WeaponType.SCYTHE:
                localizedName = "낫";
                break;
            case WeaponType.LANCE:
                localizedName = "랜스";
                break;
            case WeaponType.BOW:
                localizedName = "활";
                break;
            case WeaponType.CHAKRAM:
                localizedName = "챠크람";
                break;
            case WeaponType.JAVLIN:
                localizedName = "재블린";
                break;
        }

        return localizedName;
    }
}

public enum WeaponType
{
    PISTOL, // 쌍권총
    BLADE, // 태도
    HEAVY, // 대포
    TWO_HANDED, // 대검
    CROSS, // 십자가
    FISTS, // 건틀릿
    SCYTHE, // 낫
    LANCE, // 랜스
    BOW, // 활
    CHAKRAM, // 차크람
    JAVLIN // 재블린
}
