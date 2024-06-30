using System.Collections.Generic;
using System.ComponentModel;

/// <summary>
/// 게임에서 사용할 수많은 데이터들을 정리해 둔 외부 파일로부터, 필요한 데이터들을 알맞게 추출하여 보관하기 위한 클래스입니다.
/// </summary>
public class DataMapper
{
    /// <summary>
    /// 발키리(캐릭터)에 대한 데이터
    /// </summary>
    public class Valkyrie
    {
        public string Valkyrie_ID { get; set; } // 식별자
        public string Name { get; set; } // 이름
        public string Rank { get; set; } // 랭크
        public int Level { get; set; } // 레벨
        public string Type { get; set; } // 속성
        public List<string> Traits { get; set; } // 특성
        public int HP { get; set; } // 체력
        public int SP { get; set; } // SP(스킬 포인트)
        public int ATK { get; set; } // 공격력
        public int DEF { get; set; } // 방어력
        public int CRT { get; set; } // 회심
        public string Weapon { get; set; } // 무기
        public string Stigmata_T { get; set; } // 성흔 (상)
        public string Stigmata_M { get; set; } // 성흔 (중)
        public string Stigmata_B { get; set; } // 성흔 (하)
        public string LeaderSkill { get; set; } // 리더 스킬
        public string Passive { get; set; } // 패시브
        public string Evasion { get; set; } // 회피
        public string WeaponSkill { get; set; } // 무기 스킬
        public string Basic_ATK { get; set; } // 기본 공격
        public string Ultimate { get; set; } // 필살기
        public string Special_Attack { get; set; } // 특수 공격
        public string Description { get; set; } // 설명문
    }

    /// <summary>
    /// 발키리가 가지는 속성에 대한 데이터
    /// </summary>
    public class Type
    {
        public string Type_ID { get; set; } // 식별자
        public string Name { get; set; } // 이름
        public string Advantage { get; set; } // 상성
        public string Disadvantage { get; set; } // 역상성
        public string IconPath { get; set; } // 아이콘 이미지 경로
    }

    /// <summary>
    /// 발키리가 가지는 특성에 대한 데이터
    /// </summary>
    public class Trait
    {
        public string Trait_ID { get; set; } // 식별자
        public string Name { get; set; } // 이름
        public string IconPath { get; set; } // 아이콘 이미지 경로
        public string Description { get; set; } // 설명문
    }

    /// <summary>
    /// 무기에 대한 데이터
    /// </summary>
    public class Weapon
    {
        public string Weapon_ID { get; set; } // 식별자
        public string Name { get; set; } // 이름
        public int Rank { get; set; } // 랭크
        public int Level { get; set; } // 레벨
        public int ATK { get; set; } // 공격력
        public int CRT { get; set; } // 회심
        public List<string> Skills { get; set; } // 무기 스킬
    }

    /// <summary>
    /// 무기가 가지는 스킬에 대한 데이터
    /// </summary>
    public class WeaponSkill
    {
        public string WeaponSkill_ID { get; set; } // 식별자
        public string Name { get; set; } // 이름
        public int SP { get; set; } // SP 소모량
        public int CD { get; set; } // 재사용 대기시간
        public string Description { get; set; } // 설명문
    }

    public class Stigmata
    {
        public string Stigmata_ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Rank { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int SP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int CRT { get; set; }
        public string Skill { get; set; }
        public string SetBonuses_2Set { get; set; }
        public string SetBonuses_3Set { get; set; }
    }
}
