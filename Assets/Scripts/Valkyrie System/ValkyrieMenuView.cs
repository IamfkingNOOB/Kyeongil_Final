using System;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ValkyrieMenuView : MonoBehaviour
{
    #region UI: Selected Valkyrie

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

    #endregion UI: Selected Valkyrie

    #region UI: List Selector (Scroll View)

    // Filter Button
    [SerializeField] private Button Button_ListFilter;

    // Show Mode Button
    [SerializeField] private Button Button_ShowMode;

    // Scroll View
    [SerializeField] private ScrollRect ScrollRect_ValkyrieList;

    // Scroll View Item
    [SerializeField] private GameObject Prefab_ValkyrieListItem;

    #endregion UI: List Selector (Scroll View)

    // View Model
    private ValkyrieMenuModel _viewModel;

    private void OnEnable()
    {
        if (_viewModel == null)
        {
            _viewModel = new ValkyrieMenuModel();
            _viewModel.PropertyChanged += OnPropertyChanged;
        }

        UpdateListItem(ScrollRect_ValkyrieList);
    }

    private void OnDisable()
    {
        if (_viewModel != null)
        {
            _viewModel.PropertyChanged -= OnPropertyChanged;
            _viewModel = null;
        }
    }

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
            case nameof(_viewModel.WeaponPrefab):
                Button_Weapon.image.sprite = _viewModel.WeaponPrefab;
                break;
            case nameof(_viewModel.Stigmata_T):
                Buttons_Stigmata[0].image.sprite = _viewModel.Stigmata_T;
                break;
            case nameof(_viewModel.Stigmata_M):
                Buttons_Stigmata[1].image.sprite = _viewModel.Stigmata_M;
                break;
            case nameof(_viewModel.Stigmata_B):
                Buttons_Stigmata[2].image.sprite = _viewModel.Stigmata_B;
                break;
            default:
                break;
        }
    }

    private void UpdateListItem(ScrollRect valkyrieList)
    {
        Dictionary<int, Valkyrie> valkyrieDictionary = ValkyrieManager.Instance.ValkyrieDictionary;

        foreach (Valkyrie valkyrie in valkyrieDictionary.Values)
        {
            GameObject newItem = Instantiate(Prefab_ValkyrieListItem, valkyrieList.content);
            
            if (newItem.gameObject.TryGetComponent(out ValkyrieListItem item))
            {
                item.Initialize(_viewModel, valkyrie);
            }
        }
    }
}