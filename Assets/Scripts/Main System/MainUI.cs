using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 메인 화면의 UI를 관리하는 클래스입니다.
/// </summary>
public class MainUI : MonoBehaviour
{
    #region 변수

    // UI Toolkit; UXML의 UI 요소에 접근하기 위한 Root Visual Element
    private VisualElement root;

    // UI Elements; UI Builder(UXML)를 사용하여 생성한 UI 요소들
    private Button _valkyrieButton; // 발키리(캐릭터)
    private Button _battleButton; // 전투
    private Button _equipmentButton; // 장비
    private Button _gachaButton; // 뽑기(가챠)

    #endregion 변수

    #region 유니티 생명 주기 함수

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        // Q<>("_name")으로 접근할 수 있다.
        _battleButton = root.Q<Button>("Battle_Button");
        _battleButton.clicked += () => Debug.Log("Battle Button Clicked!");
    }

    #endregion 유니티 생명 주기 함수
}
