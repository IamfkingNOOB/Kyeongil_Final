using UnityEngine;

/// <summary>
/// 메인 화면에 등장하는 캐릭터를 관리하는 클래스입니다.
/// </summary>
public class MainCharacter : MonoBehaviour
{
    // 메인 화면에 등장하는 캐릭터
    [SerializeField] private BaseCharacterInfo _mainCharacter;

    // 게임 시작 시,
    private void Start()
    {
        // 기존에 등록된 메인 캐릭터가 있는지 검사합니다.
        int index = PlayerPrefsList.Instance._mainCharacterIndex;

        if (index == -1) // 등록된 매인 캐릭터가 없다면,
        {
            // 등록된 캐릭터의 목록 중 무작위로 하나를 고릅니다.
            index = Random.Range(0, CharacterDictionary.Instance.characterDictionary.Count);
        }

        // 선택된 캐릭터를 메인 캐릭터로 설정합니다.
        //SetMainCharacter((Valkyrie)index);

        // _mainCharacter = CharacterDictionary.Instance.characterDictionary[(ValkyrieName)index];
    }

    // 메인 캐릭터를 설정합니다.
    //public void SetMainCharacter(ValkyrieName valkyrieName)
    //{
    //    _mainCharacter = CharacterDictionary.Instance.characterDictionary[valkyrieName];

    //    Instantiate(_mainCharacter.gameObject, transform);
    //}
}
