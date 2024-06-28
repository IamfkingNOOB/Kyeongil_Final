using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터의 목록을 관리하는 클래스입니다.
/// </summary>
public class CharacterDictionary : Singleton<CharacterDictionary>
{
    public Dictionary<ValkyrieName, BasePlayerController> characterDictionary { get; set; } = new Dictionary<ValkyrieName, BasePlayerController>();

    [SerializeField] private BasePlayerController _theresa_C7;
}