using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    // UI Toolkit; UXML의 UI 요소에 접근하기 위한 Root Visual Element
    private VisualElement root;

    // UI Elements; UI Builder(UXML)에서 작업하여 생성한 UI 요소들
    private Button _valkyrieButton; // 발키리(캐릭터)
    private Button _battleButton; // 전투
    private Button _equipmentButton; // 장비
    private Button _gachaButton; // 뽑기(가챠)

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        _battleButton = root.Q<Button>("Battle_Button");
        _battleButton.clicked += () => Debug.Log("Battle Button Clicked!");
    }
}
