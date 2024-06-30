using System.Collections.Generic;

/// <summary>
/// 캐릭터의 목록을 관리하는 클래스입니다.
/// </summary>
public class CharacterDictionary : Singleton<CharacterDictionary>
{
    public Dictionary<Valkyrie, BaseCharacterInfo> characterDictionary { get; set; } = new Dictionary<Valkyrie, BaseCharacterInfo>();
}