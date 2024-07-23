using UnityEngine;

/// <summary>
/// 성흔에 대한 데이터
/// </summary>
public class Stigmata
{
    // 식별자
    public int StigmataID { get; set; } // 식별자
    public string Name { get; set; } // 이름
    public StigmataPosition Position { get; set; } // 부위 (상, 중, 하)

    // 스탯 (플레이어)
    public int Rank { get; set; } // 랭크
    public int Level { get; set; } // 레벨

    // 스탯 (성흔)
    public int HP { get; set; } // 체력
    public int SP { get; set; } // SP(스킬 포인트)
    public int ATK { get; set; } // 공격력
    public int DEF { get; set; } // 방어력
    public int CRT { get; set; } // 회심

    // 스킬
    public string Skill { get; set; } // 스킬
    public string Set2 { get; set; } // 스킬 2 세트
    public string Set3 { get; set; } // 스킬 3 세트

    // 모델
    public Sprite Icon { get; set; } // 아이콘
    public Sprite Model { get; set; } // 모델 (일러스트)
}

public enum StigmataPosition
{
    TOP, // 상
    MIDDLE, // 중
    BOTTOM // 하
}
