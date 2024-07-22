using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

/// <summary>
/// 외부 파일에 접근하여, 필요한 데이터를 추출하고 보관하기 위한 클래스입니다.
/// </summary>
public static class DataManager
{
    // 외부 파일에 접근하기 위한 경로
    private readonly static string _dataRootPath = "C:/...";

    // 사용하고자 하는 데이터 목록
    private static Dictionary<int, Valkyrie> _valkyrieList; // 발키리 목록
    private static Dictionary<int, Weapon> _weaponList; // 무기 목록
    private static Dictionary<int, Stigmata> _stigmataList; // 성흔 목록

    #region 프로퍼티(Property)

    public static Dictionary<int, Valkyrie> ValkyrieList
    {
        get
        {
            if (_valkyrieList == null)
            {
                ReadValkyrieTable(nameof(Valkyrie));
            }

            return _valkyrieList;
        }
    }

    public static Dictionary<int, Weapon> WeaponList
    {
        get
        {
            if (_weaponList == null)
            {
                ReadWeaponTable(nameof(Weapon));
            }

            return _weaponList;
        }
    }

    public static Dictionary<int, Stigmata> StigmataList
    {
        get
        {
            if (_stigmataList == null)
            {
                ReadStigmataTable(nameof(Stigmata));
            }

            return _stigmataList;
        }
    }

    #endregion 프로퍼티(Property)

    // 발키리의 데이터를 읽어내어 저장합니다.
    private static void ReadValkyrieTable(string tableName)
    {
        // 발키리 목록을 생성합니다.
        _valkyrieList = new Dictionary<int, Valkyrie>();

        // XML 파일을 읽어, 분석하여 저장합니다.
        XDocument xDocument = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
        IEnumerable<XElement> dataElements = xDocument.Descendants();

        foreach (XElement dataElement in dataElements)
        {
            Valkyrie valkyrie = new Valkyrie();

            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.ValkyrieID)).Value, out int id)) { valkyrie.ValkyrieID = id; }
            valkyrie.CharacterName = dataElement.Attribute(nameof(valkyrie.CharacterName)).Value;
            valkyrie.SuitName = dataElement.Attribute(nameof(valkyrie.SuitName)).Value;

            if (Enum.TryParse(dataElement.Attribute(nameof(valkyrie.Type)).Value, out EntityType type)) { valkyrie.Type = type; }
            valkyrie.Traits.AddRange(dataElement.Attribute(nameof(valkyrie.Traits)).Value.Split(',').Select(Enum.Parse<ValkyrieTrait>));

            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.RankID)).Value, out int rank)) { valkyrie.RankID = rank; }
            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.Level)).Value, out int level)) { valkyrie.Level = level; }

            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.HP)).Value, out int hp)) { valkyrie.HP = hp; }
            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.SP)).Value, out int sp)) { valkyrie.SP = sp; }
            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.ATK)).Value, out int atk)) { valkyrie.ATK = atk; }
            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.DEF)).Value, out int def)) { valkyrie.DEF = def; }
            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.CRT)).Value, out int crt)) { valkyrie.CRT = crt; }

            if (Enum.TryParse(dataElement.Attribute(nameof(valkyrie.EquipableWeaponType)).Value, out WeaponType weaponType)) { valkyrie.EquipableWeaponType = weaponType; }
            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.WeaponID)).Value, out int weapon)) { valkyrie.WeaponID = _weaponList[weapon]; }
            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.StigmataTopID)).Value, out int top)) { valkyrie.StigmataTopID = _stigmataList[top]; }
            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.StigmataMiddleID)).Value, out int middle)) { valkyrie.StigmataMiddleID = _stigmataList[middle]; }
            if (int.TryParse(dataElement.Attribute(nameof(valkyrie.StigmataBottomID)).Value, out int bottom)) { valkyrie.StigmataBottomID = _stigmataList[bottom]; }

            valkyrie.LeaderSkill = dataElement.Attribute(nameof(valkyrie.LeaderSkill)).Value;
            valkyrie.Passive = dataElement.Attribute(nameof(valkyrie.Passive)).Value;
            valkyrie.Evasion = dataElement.Attribute(nameof(valkyrie.Evasion)).Value;
            valkyrie.WeaponSkill = dataElement.Attribute(nameof(valkyrie.WeaponSkill)).Value;
            valkyrie.BasicATK = dataElement.Attribute(nameof(valkyrie.BasicATK)).Value;
            valkyrie.Ultimate = dataElement.Attribute(nameof(valkyrie.Ultimate)).Value;
            valkyrie.SpecialATK = dataElement.Attribute(nameof(valkyrie.SpecialATK)).Value;

            valkyrie.Description = dataElement.Attribute(nameof(valkyrie.Description)).Value;

            valkyrie.Portrait = Resources.Load<Sprite>(dataElement.Attribute(nameof(valkyrie.Portrait)).Value);
            valkyrie.Model = Resources.Load<GameObject>(dataElement.Attribute(nameof(valkyrie.Model)).Value);

            _valkyrieList.Add(valkyrie.ValkyrieID, valkyrie);
        }
    }

    // 무기의 데이터를 읽어내어 저장합니다.
    private static void ReadWeaponTable(string tableName)
    {
        // 무기 목록을 생성합니다.
        _weaponList = new Dictionary<int, Weapon>();

        // XML 파일을 읽어, 분석하여 저장합니다.
        XDocument xDocument = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
        IEnumerable<XElement> dataElements = xDocument.Descendants();

        foreach (XElement dataElement in dataElements)
        {
            Weapon weapon = new Weapon();

            if (int.TryParse(dataElement.Attribute(nameof(weapon.WeaponID)).Value, out int id)) { weapon.WeaponID = id; }
            weapon.Name = dataElement.Attribute(nameof(weapon.Name)).Value;
            if (Enum.TryParse(dataElement.Attribute(nameof(weapon.Type)).Value, out WeaponType type)) { weapon.Type = type; }

            if (int.TryParse(dataElement.Attribute(nameof(weapon.Rank)).Value, out int rank)) { weapon.Rank = rank; }
            if (int.TryParse(dataElement.Attribute(nameof(weapon.Level)).Value, out int level)) { weapon.Level = level; }

            if (int.TryParse(dataElement.Attribute(nameof(weapon.ATK)).Value, out int atk)) { weapon.ATK = atk; }
            if (int.TryParse(dataElement.Attribute(nameof(weapon.CRT)).Value, out int crt)) { weapon.CRT = crt; }

            weapon.Skills.AddRange(dataElement.Attribute(nameof(weapon.Skills)).Value.Split(','));

            weapon.Description = dataElement.Attribute(nameof(weapon.Description)).Value;

            weapon.Icon = Resources.Load<Sprite>(dataElement.Attribute(nameof(weapon.Icon)).Value);
            weapon.Model = Resources.Load<GameObject>(dataElement.Attribute(nameof(weapon.Model)).Value);

            _weaponList.Add(weapon.WeaponID, weapon);
        }
    }

    // 성흔의 데이터를 읽어내어 저장합니다.
    private static void ReadStigmataTable(string tableName)
    {
        // 성흔 목록을 생성합니다.
        _stigmataList = new Dictionary<int, Stigmata>();

        // XML 파일을 읽어, 분석하여 저장합니다.
        XDocument xDocument = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
        IEnumerable<XElement> dataElements = xDocument.Descendants();

        foreach (XElement dataElement in dataElements)
        {
            Stigmata stigmata = new Stigmata();

            if (int.TryParse(dataElement.Attribute(nameof(stigmata.StigmataID)).Value, out int id)) { stigmata.StigmataID = id; }
            stigmata.Name = dataElement.Attribute(nameof(stigmata.Name)).Value;
            if (Enum.TryParse(dataElement.Attribute(nameof(stigmata.Position)).Value, out StigmataPosition position)) { stigmata.Position = position; }

            if (int.TryParse(dataElement.Attribute(nameof(stigmata.Rank)).Value, out int rank)) { stigmata.Rank = rank; }
            if (int.TryParse(dataElement.Attribute(nameof(stigmata.Level)).Value, out int level)) { stigmata.Level = level; }

            if (int.TryParse(dataElement.Attribute(nameof(stigmata.HP)).Value, out int hp)) { stigmata.HP = hp; }
            if (int.TryParse(dataElement.Attribute(nameof(stigmata.SP)).Value, out int sp)) { stigmata.SP = sp; }
            if (int.TryParse(dataElement.Attribute(nameof(stigmata.ATK)).Value, out int atk)) { stigmata.ATK = atk; }
            if (int.TryParse(dataElement.Attribute(nameof(stigmata.DEF)).Value, out int def)) { stigmata.DEF = def; }
            if (int.TryParse(dataElement.Attribute(nameof(stigmata.CRT)).Value, out int crt)) { stigmata.CRT = crt; }

            stigmata.Skill = dataElement.Attribute(nameof(stigmata.Skill)).Value;
            stigmata.Set2 = dataElement.Attribute(nameof(stigmata.Set2)).Value;
            stigmata.Set3 = dataElement.Attribute(nameof(stigmata.Set3)).Value;

            stigmata.Icon = Resources.Load<Sprite>(dataElement.Attribute(nameof(stigmata.Icon)).Value);
            stigmata.Model = Resources.Load<Sprite>(dataElement.Attribute(nameof(stigmata.Model)).Value);

            _stigmataList.Add(stigmata.StigmataID, stigmata);
        }
    }
}
