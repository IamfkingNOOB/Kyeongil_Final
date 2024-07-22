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
    #region UI: 선택한 발키리

    // Menu Button
    [SerializeField] private Button Button_Back;
    [SerializeField] private Button Button_Home;

    // Status
    [SerializeField] private TextMeshProUGUI Text_ValkyrieName;
    [SerializeField] private Image Image_Rank;
    [SerializeField] private TextMeshProUGUI Text_SuitName;
    [SerializeField] private Button Button_Level;
    [SerializeField] private Button Button_Type;
    [SerializeField] private Button[] Buttons_Traits;

    // Skill
    [SerializeField] private Button Button_Skill;

    // Weapon
    [SerializeField] private TextMeshProUGUI Text_Weapon;
    [SerializeField] private Button Button_Weapon;

    // Stigmata
    [SerializeField] private Button[] Buttons_Stigmata;

    #endregion UI: 선택한 발키리

    #region UI: 발키리 목록 (스크롤 뷰)

    // Filter Button
    [SerializeField] private Button Button_ListFilter;

    // Show Mode Button
    [SerializeField] private Button Button_ShowMode;

    // Scroll View
    [SerializeField] private ScrollRect ScrollRect_ValkyrieList;

    // Scroll View Item
    [SerializeField] private GameObject Prefab_ValkyrieListItem;

    #endregion UI: 발키리 목록 (스크롤 뷰)

    // View Model
    private ValkyrieMenuModel _viewModel;

    #region 유니티 생명 주기 함수

    // 활성화할 때,
    private void OnEnable()
    {
        // 뷰 모델(View Model)을 생성하고, 프로퍼티 변경 이벤트를 등록합니다.
        if (_viewModel == null)
        {
            _viewModel = new ValkyrieMenuModel();
            _viewModel.PropertyChanged += OnPropertyChanged;
        }

        // 발키리의 목록을 보여주는 스크롤 뷰의 아이템을 갱신합니다.
        UpdateListItem(ScrollRect_ValkyrieList);
    }

    // 비활성화할 때,
    private void OnDisable()
    {
        // 프로퍼티 변경 이벤트를 해제하고, 뷰 모델(View Model)을 삭제합니다.
        if (_viewModel != null)
        {
            _viewModel.PropertyChanged -= OnPropertyChanged;
            _viewModel = null;
        }
    }

    #endregion 유니티 생명 주기 함수

    #region 커스텀 함수

    // 프로퍼티 변경 이벤트를 정의합니다.
    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        Debug.Log(e.PropertyName);
        Debug.Log(_viewModel.ValkyrieName);

        switch (e.PropertyName)
        {
            case nameof(_viewModel.ValkyrieName):
                Text_ValkyrieName.text = _viewModel.ValkyrieName;
                break;
            case nameof(_viewModel.Rank):
                Image_Rank.sprite = _viewModel.Rank;
                break;
            case nameof(_viewModel.SuitName):
                Text_SuitName.text = _viewModel.SuitName;
                break;
            case nameof(_viewModel.WeaponName):
                Text_Weapon.text = _viewModel.WeaponName;
                break;
            case nameof(_viewModel.WeaponIcon):
                Button_Weapon.image.sprite = _viewModel.WeaponIcon;
                break;
            case nameof(_viewModel.StigmataTop):
                Buttons_Stigmata[0].image.sprite = _viewModel.StigmataTop;
                break;
            case nameof(_viewModel.StigmataMiddle):
                Buttons_Stigmata[1].image.sprite = _viewModel.StigmataMiddle;
                break;
            case nameof(_viewModel.StigmataBottom):
                Buttons_Stigmata[2].image.sprite = _viewModel.StigmataBottom;
                break;
            default:
                break;
        }
    }

    // 발키리의 목록을 보여주는 스크롤 뷰의 아이템을 갱신합니다.
    private void UpdateListItem(ScrollRect scrollRect)
    {
        // 발키리 목록을 가져옵니다.
        Dictionary<int, Valkyrie> valkyrieList = DataManager.ValkyrieList;

        // 발키리 목록을 순회하면서,
        foreach (Valkyrie valkyrie in valkyrieList.Values)
        {
            // 스크롤 뷰의 컨텐츠 영역에 아이템을 생성하고,
            GameObject newItem = Instantiate(Prefab_ValkyrieListItem, scrollRect.content);
            
            // 아이템의 요소를 초기화합니다.
            if (newItem.gameObject.TryGetComponent(out ValkyrieListItem item))
            {
                item.Initialize(_viewModel, valkyrie);
            }
        }
    }

    #endregion 커스텀 함수
}
