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
        _valkyrieButton = root.Q<Button>("Valkyrie_Button");
        _battleButton = root.Q<Button>("Battle_Button");
        _equipmentButton = root.Q<Button>("Equipment_Button");
        _gachaButton = root.Q<Button>("Gacha_Button");

        // .clicked += / RegisterCallback()으로 클릭 이벤트를 등록할 수 있다.
        //_battleButton.clicked += () => Debug.Log("Battle Button Clicked!");
        //_battleButton.RegisterCallback((ClickEvent evt) => Debug.Log("Battle Button Clicked!"));

        Debug.Log("Awake!");
    }

    // 활성화될 때,
    private void OnEnable()
    {
        // 버튼에 이벤트를 등록합니다.
        Debug.Log("OnEnable!");
        RegisterClickEvent();
    }

    // 비활성화될 때,
    private void OnDisable()
    {
        // 버튼에 이벤트를 해제합니다.
        UnregisterClickEvent();
    }

    // 버튼에 클릭 이벤트를 등록합니다.
    private void RegisterClickEvent()
    {
        _valkyrieButton.clicked += OnLoadValkyrieSystem;
        _battleButton.clicked += OnLoadBattleSystem;
        _equipmentButton.clicked += OnLoadEquipmentSystem;
        _gachaButton.clicked += OnLoadGachaSystem;
    }

    // 버튼에 클릭 이벤트를 해제합니다.
    private void UnregisterClickEvent()
    {
        _valkyrieButton.clicked -= OnLoadValkyrieSystem;
        _battleButton.clicked -= OnLoadBattleSystem;
        _equipmentButton.clicked -= OnLoadEquipmentSystem;
        _gachaButton.clicked -= OnLoadGachaSystem;
    }

    // 발키리 버튼 이벤트
    private void OnLoadValkyrieSystem()
    {
        Debug.Log("Valkyrie Button is Clicked!");
    }

    // 출격 버튼 이벤트
    private void OnLoadBattleSystem()
    {
        Debug.Log("Battle Button is Clicked!");
    }

    // 장비 버튼 이벤트
    private void OnLoadEquipmentSystem()
    {
        Debug.Log("Equipment Button is Clicked!");
    }

    // 보급 버튼 이벤트
    private void OnLoadGachaSystem()
    {
        Debug.Log("Gacha Button is Clicked!");
    }

    #endregion 유니티 생명 주기 함수
}
