using UnityEngine.UIElements;

public class CharacterListEntryController // Entry : 항목
{
    private Label m_NameLabel;

    // This function retrieves a reference to the character name label inside the UI element.
    // 이 함수는 UIElement 안의 캐릭터 이름 Label에의 참조를 검색합니다.
    public void SetVisualElement(VisualElement visualElement)
    {
        m_NameLabel = visualElement.Q<Label>("character-name");
    }


    // This function receives the character whose name this list element is supposed to display.
    // Since the elements list in a 'ListView' are pooled and reused,
    // it's necessary to have a 'Set' function to change which character's data to display.

    // 이 함수는 이 List 요소가 보여주어야 할 이름의 캐릭터를 받습니다.
    // 'ListView' 안의 요소들의 목록은 풀링(Pool) 및 재사용되므로,
    // 보여주어야 할 캐릭터의 데이터를 바꾸는 'Set' 함수를 가져야 합니다.
    public void SetCharacterData(CharacterData characterData)
    {
        m_NameLabel.text = characterData.CharacterName;
    }
}