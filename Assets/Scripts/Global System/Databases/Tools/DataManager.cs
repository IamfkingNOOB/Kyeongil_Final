using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

/// <summary>
/// 외부 파일에 접근하여, 필요한 데이터를 추출하고 보관하기 위한 클래스입니다.
/// </summary>
public class DataManager : Singleton<DataManager>
{
    // 외부 파일에 접근하기 위한 경로; (Assets/Databases)
    private readonly string _dataRootPath = Path.Combine(Application.dataPath, "Databases");

    // 사용하고자 하는 데이터 목록
    private Dictionary<int, ValkyrieData> _valkyrieList; // 발키리 목록
    private Dictionary<int, Weapon> _weaponList; // 무기 목록
    private Dictionary<int, Stigmata> _stigmataList; // 성흔 목록

    #region 프로퍼티(Property)

    public Dictionary<int, ValkyrieData> ValkyrieList
    {
        get
        {
            if (_valkyrieList == null || _valkyrieList.Count == 0)
            {
                ReadValkyrieTable(nameof(Valkyrie));
            }

            return _valkyrieList;
        }
    }

    public Dictionary<int, Weapon> WeaponList
    {
        get
        {
            if (_weaponList == null || _weaponList.Count == 0)
            {
                ReadWeaponTable(nameof(Weapon));
            }

            return _weaponList;
        }
    }

    public Dictionary<int, Stigmata> StigmataList
    {
        get
        {
            if (_stigmataList == null || _stigmataList.Count == 0)
            {
                ReadStigmataTable(nameof(Stigmata));
            }

            return _stigmataList;
        }
    }

    #endregion 프로퍼티(Property)

    // 발키리의 데이터를 읽어내어 저장합니다.
    private void ReadValkyrieTable(string tableName)
    {
        // 발키리 목록을 생성합니다.
        _valkyrieList = new();

        // XML 파일을 읽어, 분석하여 저장합니다.
        XDocument xDocument = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
        IEnumerable<XElement> dataElements = xDocument.Descendants("data");

        foreach (XElement dataElement in dataElements)
        {
            ValkyrieDataStruct data = new();

            // Valkyrie valkyrie = new();

            if (int.TryParse(dataElement.Attribute(nameof(data.ValkyrieID)).Value, out int id)) { data.ValkyrieID = id; }
            data.CharacterName = dataElement.Attribute(nameof(data.CharacterName)).Value;
            data.SuitName = dataElement.Attribute(nameof(data.SuitName)).Value;

            if (Enum.TryParse(dataElement.Attribute(nameof(data.Type)).Value.ToUpperInvariant(), out EntityType type)) { data.Type = type; }

            data.Traits = new();
            data.Traits.AddRange(dataElement.Attribute(nameof(data.Traits)).Value.ToUpperInvariant().Split(',').Select(Enum.Parse<ValkyrieTrait>));

            if (int.TryParse(dataElement.Attribute(nameof(data.Rank)).Value, out int rank)) { data.Rank = rank; }
            if (int.TryParse(dataElement.Attribute(nameof(data.Level)).Value, out int level)) { data.Level = level; }

            if (int.TryParse(dataElement.Attribute(nameof(data.HP)).Value, out int hp)) { data.HP = hp; }
            if (int.TryParse(dataElement.Attribute(nameof(data.SP)).Value, out int sp)) { data.SP = sp; }
            if (int.TryParse(dataElement.Attribute(nameof(data.ATK)).Value, out int atk)) { data.ATK = atk; }
            if (int.TryParse(dataElement.Attribute(nameof(data.DEF)).Value, out int def)) { data.DEF = def; }
            if (int.TryParse(dataElement.Attribute(nameof(data.CRT)).Value, out int crt)) { data.CRT = crt; }

            if (Enum.TryParse(dataElement.Attribute(nameof(data.EquipableWeaponType)).Value.ToUpperInvariant(), out WeaponType weaponType)) { data.EquipableWeaponType = weaponType; }
            if (int.TryParse(dataElement.Attribute(nameof(data.WeaponID)).Value, out int weapon)) { data.WeaponID = WeaponList[weapon]; }
            if (int.TryParse(dataElement.Attribute(nameof(data.StigmataTopID)).Value, out int top)) { data.StigmataTopID = StigmataList[top]; }
            if (int.TryParse(dataElement.Attribute(nameof(data.StigmataMiddleID)).Value, out int middle)) { data.StigmataMiddleID = StigmataList[middle]; }
            if (int.TryParse(dataElement.Attribute(nameof(data.StigmataBottomID)).Value, out int bottom)) { data.StigmataBottomID = StigmataList[bottom]; }

            data.LeaderSkill = dataElement.Attribute(nameof(data.LeaderSkill)).Value;
            data.Passive = dataElement.Attribute(nameof(data.Passive)).Value;
            data.Evasion = dataElement.Attribute(nameof(data.Evasion)).Value;
            data.WeaponSkill = dataElement.Attribute(nameof(data.WeaponSkill)).Value;
            data.BasicATK = dataElement.Attribute(nameof(data.BasicATK)).Value;
            data.Ultimate = dataElement.Attribute(nameof(data.Ultimate)).Value;
            data.SpecialATK = dataElement.Attribute(nameof(data.SpecialATK)).Value;

            data.Description = dataElement.Attribute(nameof(data.Description)).Value;

            data.Portrait = Resources.Load<Sprite>(dataElement.Attribute(nameof(data.Portrait)).Value);
            data.Model = Resources.Load<GameObject>(dataElement.Attribute(nameof(data.Model)).Value);

            ValkyrieData valkyrieData = new(data);

            _valkyrieList.Add(valkyrieData.ValkyrieID, valkyrieData);
        }
    }

    // 무기의 데이터를 읽어내어 저장합니다.
    private void ReadWeaponTable(string tableName)
    {
        // 무기 목록을 생성합니다.
        _weaponList = new();

        // XML 파일을 읽어, 분석하여 저장합니다.
        XDocument xDocument = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
        IEnumerable<XElement> dataElements = xDocument.Descendants("data");

        foreach (XElement dataElement in dataElements)
        {
            Weapon weapon = new();

            if (int.TryParse(dataElement.Attribute(nameof(weapon.WeaponID)).Value, out int id)) { weapon.WeaponID = id; }
            weapon.Name = dataElement.Attribute(nameof(weapon.Name)).Value;
            if (Enum.TryParse(dataElement.Attribute(nameof(weapon.Type)).Value.ToUpperInvariant(), out WeaponType type)) { weapon.Type = type; }

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
    private void ReadStigmataTable(string tableName)
    {
        // 성흔 목록을 생성합니다.
        _stigmataList = new();

        // XML 파일을 읽어, 분석하여 저장합니다.
        XDocument xDocument = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
        IEnumerable<XElement> dataElements = xDocument.Descendants("data");

        foreach (XElement dataElement in dataElements)
        {
            Stigmata stigmata = new();

            if (int.TryParse(dataElement.Attribute(nameof(stigmata.StigmataID)).Value, out int id)) { stigmata.StigmataID = id; }
            stigmata.Name = dataElement.Attribute(nameof(stigmata.Name)).Value;
            if (Enum.TryParse(dataElement.Attribute(nameof(stigmata.Position)).Value.ToUpperInvariant(), out StigmataPosition position)) { stigmata.Position = position; }

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

            Debug.Log("Model = " + stigmata.Model);

            _stigmataList.Add(stigmata.StigmataID, stigmata);
        }
    }
}

// 문자열을 제목 형식(APPLE → Apple; 첫 글자는 대문자, 이후는 소문자)으로 변환해 주는 확장 메서드
public static class StringExtensions
{
    public static string ToTitleInvariant(this string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            input = char.ToUpperInvariant(input[0]) + input[1..].ToLowerInvariant();
        }

        return input;
    }
}

// 생성자로 전달할 데이터; 하나의 매개변수만을 사용하고자 구조체로 묶는다.
public struct ValkyrieDataStruct
{
    public int ValkyrieID;
    public string CharacterName;
    public string SuitName;

    public EntityType Type;
    public List<ValkyrieTrait> Traits;

    public int Rank;
    public int Level;

    public WeaponType EquipableWeaponType;

    public Weapon WeaponID;
    public Stigmata StigmataTopID;
    public Stigmata StigmataMiddleID;
    public Stigmata StigmataBottomID;

    public string LeaderSkill;
    public string Passive;
    public string Evasion;
    public string WeaponSkill;
    public string BasicATK;
    public string Ultimate;
    public string SpecialATK;

    public string Description;

    public Sprite Portrait;
    public GameObject Model;

    public int HP;
    public int SP;
    public int ATK;
    public int DEF;
    public int CRT;
    public int UltimateCost;
}
