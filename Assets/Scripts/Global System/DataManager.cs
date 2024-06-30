using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

/// <summary>
/// 외부 파일에 접근하여, 필요한 데이터를 추출하고 보관하기 위한 클래스입니다.
/// </summary>
public class DataManager : MonoBehaviour
{
    // 싱글톤으로 구현하기 위한 인스턴스
    public static DataManager Instance { get; private set; }

    // 외부 파일에 접근하기 위한 경로
    private readonly string _dataRootPath = "C:/...";

    public Dictionary<string, Valkyrie> ValkyrieList { get; private set; }
    public Dictionary<string, Type> TypeList { get; private set; }
    public Dictionary<string, Trait> TraitList { get; private set; }
    public Dictionary<string, Weapon> WeaponList { get; private set; }
    public Dictionary<string, WeaponSkill> WeaponSkillList { get; private set; }
    public Dictionary<string, Stigmata> StigmataList { get; private set; }

    private void Awake()
    {
        Instance = this;

        ReadAllData();
    }

    private void ReadAllData()
    {
        ReadValkyrieTable(nameof(Valkyrie));
    }

    private void ReadValkyrieTable(string tableName)
    {
        ValkyrieList = new Dictionary<string, Valkyrie>();

        XDocument xDocument = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
        IEnumerable<XElement> dataElements = xDocument.Descendants();

        foreach (XElement dataElement in dataElements)
        {
            Valkyrie valkyrie = new Valkyrie();

            // Stat
            valkyrie.Valkyrie_ID = dataElement.Attribute(nameof(valkyrie.Valkyrie_ID)).Value;
            valkyrie.Name = dataElement.Attribute(nameof(valkyrie.Name)).Value;
            valkyrie.Rank = dataElement.Attribute(nameof(valkyrie.Rank)).Value;
            valkyrie.Level = int.Parse(dataElement.Attribute(nameof(valkyrie.Level)).Value);
            valkyrie.Type = dataElement.Attribute(nameof(valkyrie.Type)).Value;
            valkyrie.HP = int.Parse(dataElement.Attribute(nameof(valkyrie.HP)).Value);
            valkyrie.SP = int.Parse(dataElement.Attribute(nameof(valkyrie.SP)).Value);
            valkyrie.ATK = int.Parse(dataElement.Attribute(nameof(valkyrie.ATK)).Value);
            valkyrie.DEF = int.Parse(dataElement.Attribute(nameof(valkyrie.DEF)).Value);
            valkyrie.CRT = int.Parse(dataElement.Attribute(nameof(valkyrie.CRT)).Value);
            
            // Weapon, Stigmata
            valkyrie.Weapon = dataElement.Attribute(nameof(valkyrie.Weapon)).Value;
            valkyrie.Stigmata_T = dataElement.Attribute(nameof(valkyrie.Stigmata_T)).Value;
            valkyrie.Stigmata_M = dataElement.Attribute(nameof(valkyrie.Stigmata_M)).Value;
            valkyrie.Stigmata_B = dataElement.Attribute(nameof(valkyrie.Stigmata_B)).Value;

            // Skill
            valkyrie.LeaderSkill = dataElement.Attribute(nameof(valkyrie.LeaderSkill)).Value;
            valkyrie.Passive = dataElement.Attribute(nameof(valkyrie.Passive)).Value;
            valkyrie.Evasion = dataElement.Attribute(nameof(valkyrie.Evasion)).Value;
            valkyrie.WeaponSkill = dataElement.Attribute(nameof(valkyrie.WeaponSkill)).Value;
            valkyrie.Basic_ATK = dataElement.Attribute(nameof(valkyrie.Basic_ATK)).Value;
            valkyrie.Ultimate = dataElement.Attribute(nameof(valkyrie.Ultimate)).Value;
            valkyrie.Special_Attack = dataElement.Attribute(nameof(valkyrie.Special_Attack)).Value;
            valkyrie.Description = dataElement.Attribute(nameof(valkyrie.Description)).Value;
        }
    }

    private void ReadTypeTable(string tableName) { }
    private void ReadTraitTable(string tableName) { }
    private void ReadWeaponTable(string tableName) { }
    private void ReadWeaponSkillTable(string tableName) { }
    private void ReadStigmataTable(string tableName) { }

}
