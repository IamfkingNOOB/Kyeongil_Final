using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 발키리 화면에서, UI를 관리하는 클래스입니다.
/// </summary>
public class ValkyrieMenuView : MonoBehaviour
{
    #region UI: 기본 버튼

    // 메뉴 버튼
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _homeButton;

    // 선택 버튼; 메인 발키리를 지정하거나, 출전 발키리를 지정할 수 있습니다.
    [SerializeField] private Button _selectButton;

    #endregion UI: 기본 버튼

    #region UI: 선택한 발키리

    // 스탯
    [SerializeField] private TextMeshProUGUI _characterNameText;
    [SerializeField] private Image _rankImage;
    [SerializeField] private TextMeshProUGUI _suitNameText;
    [SerializeField] private Button _levelButton;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Button _typeButton;
    [SerializeField] private Button[] _traitsButton;

    // 스킬
    [SerializeField] private Button _skillButton;

    // 무기
    [SerializeField] private TextMeshProUGUI _weaponText;
    [SerializeField] private Button _weaponButton;

    // 성흔
    [SerializeField] private Button[] _stigmataButton;

    #endregion UI: 선택한 발키리

    #region UI: 발키리 목록 (스크롤 뷰)

    // 필터, 모드 버튼
    [SerializeField] private Button _listFilterButton;
    [SerializeField] private Button _listShowModeButton;

    // 스크롤 뷰 및 아이템
    [SerializeField] private ScrollRect _listScrollRect;
    [SerializeField] private GameObject _listItem;

    #endregion UI: 발키리 목록 (스크롤 뷰)

    // 모델
    private ValkyrieMenuModel _model;

    #region 유니티 생명 주기 함수

    // 활성화할 때,
    private void OnEnable()
    {
        // 모델을 생성하고, 프로퍼티 변경 이벤트를 등록합니다.
        if (_model == null)
        {
            _model = new();
            _model.AddPropertyChangedListener(true, OnPropertyChanged);
        }

        // 발키리의 목록을 보여주는 스크롤 뷰의 아이템을 갱신합니다.
        UpdateListItem(_listScrollRect);

        AddButtonListeners();
    }

    // 비활성화할 때,
    private void OnDisable()
    {
        // 프로퍼티 변경 이벤트를 해제하고, 모델을 삭제합니다.
        if (_model != null)
        {
            _model.AddPropertyChangedListener(false, OnPropertyChanged);
            _model = null;
        }
    }

    #endregion 유니티 생명 주기 함수

    #region 커스텀 함수

    // 프로퍼티 변경 이벤트를 정의합니다.
    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(_model.CharacterName):
                _characterNameText.text = _model.CharacterName;
                break;
            case nameof(_model.Rank):
                _rankImage.sprite = _model.Rank;
                break;
            case nameof(_model.SuitName):
                _suitNameText.text = _model.SuitName;
                break;
            case nameof(_model.Level):
                _levelText.text = _model.Level;
                break;
            case nameof(_model.WeaponName):
                _weaponText.text = _model.WeaponName;
                break;
            case nameof(_model.WeaponIcon):
                _weaponButton.image.sprite = _model.WeaponIcon;
                break;
            case nameof(_model.StigmataTop):
                _stigmataButton[0].image.sprite = _model.StigmataTop;
                break;
            case nameof(_model.StigmataMiddle):
                _stigmataButton[1].image.sprite = _model.StigmataMiddle;
                break;
            case nameof(_model.StigmataBottom):
                _stigmataButton[2].image.sprite = _model.StigmataBottom;
                break;
            default:
                break;
        }
    }

    // 발키리의 목록을 보여주는 스크롤 뷰의 아이템을 갱신합니다.
    private void UpdateListItem(ScrollRect scrollRect)
    {
        // 발키리 목록을 가져옵니다.
        Dictionary<int, Valkyrie> valkyrieList = DataManager.Instance.ValkyrieList;

        // 발키리 목록을 순회하면서,
        foreach (Valkyrie valkyrie in valkyrieList.Values)
        {
            // 스크롤 뷰의 컨텐츠 영역에 아이템을 생성하고,
            GameObject newItem = Instantiate(_listItem, scrollRect.content);
            
            // 아이템의 요소를 초기화합니다.
            if (newItem.TryGetComponent(out ValkyrieListItem item))
            {
                item.Initialize(_model, valkyrie);
            }
        }
    }

    // 버튼에 클릭 이벤트를 등록합니다.
    private void AddButtonListeners()
    {
        _backButton.onClick.AddListener(() =>
        {
            MySceneManager.Instance.LoadBeforeScene();
        });

        _homeButton.onClick.AddListener(() =>
        {
            MySceneManager.Instance.LoadScene(SceneName.Main_Scene);
        });

        _selectButton.onClick.AddListener(() =>
        {
            ValkyrieSelector.Instance.SelectedValkyrie = _model.SelectedValkyrie;
        });
    }

    #endregion 커스텀 함수
}
