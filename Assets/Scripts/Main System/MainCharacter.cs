using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 메인 화면에 등장하는 캐릭터를 관리하는 클래스입니다.
/// </summary>
public class MainCharacter : MonoBehaviour
{
    // 메인 화면에 등장하는 캐릭터
    private BasePlayerController _mainCharacter;

    public Dictionary<int, int> a = new Dictionary<int, int>(); 

    private void Awake()
    {
        // 캐릭터 목록에서 무작위로 하나를 골라, 메인 화면의 캐릭터로 설정한다.
        int characterCount = Random.Range(0, CharacterDictionary.Instance.characterDictionary.Count);
        _mainCharacter = CharacterDictionary.Instance.characterDictionary[(ValkyrieName)characterCount];


    }
}
