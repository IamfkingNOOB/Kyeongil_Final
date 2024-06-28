using UnityEngine;

/// <summary>
/// 게임을 실행하는 직후, 캐릭터의 목록을 불러오는 클래스입니다.
/// </summary>
public class CharacterLoader : MonoBehaviour
{
    // 직렬화 방법을 사용하여 캐릭터 정보를 등록합니다.
    [SerializeField] private BaseCharacterInfo[] characterArray;

    // 게임 실행 시,
    private void Awake()
    {
        // 우선 캐릭터 목록을 초기화합니다.
        CharacterDictionary.Instance.characterDictionary.Clear();

        // 등록한 캐릭터의 정보들을 순회하면서, 캐릭터 목록에 등록합니다.
        foreach (BaseCharacterInfo character in characterArray)
        {
            CharacterDictionary.Instance.characterDictionary.Add(character.GetCharacterName(), character);
        }

        // 등록을 마친 후, 이 클래스가 등록된 게임 오브젝트를 삭제합니다.
        Destroy(gameObject);
    }
}
