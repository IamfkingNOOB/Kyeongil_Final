using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValkyrieMenuView : MonoBehaviour
{
    #region UI: Selected Valkyrie

    // Menu Button
    [SerializeField] private Button goToBack_Button;
    [SerializeField] private Button goToHome_Button;

    // Status
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI_ValkyrieName;
    [SerializeField] private Button Button_ValkyrieRank;
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI_ValkyrieLevel;
    [SerializeField] private Button Button_ValkyrieType;
    [SerializeField] private Button[] Buttons_ValkyrieTraits;

    // Skill
    [SerializeField] private Button Button_ValkyrieSkill;

    // Weapon
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI_ValkyrieWeapon;
    [SerializeField] private Button Button_ValkyrieWeapon;

    // Stigmata
    [SerializeField] private Button[] Buttons_ValkyrieStigmata;

    #endregion UI: Selected Valkyrie

    #region UI: List Selector (Scroll View)

    // Filter Button
    [SerializeField] private Button Button_ListFilter;

    // Scroll View
    [SerializeField] private ScrollRect ScrollRect_ValkyrieList;

    // Scroll View Item
    [SerializeField] private GameObject Prefab_ValkyrieListItem;

    #endregion UI: List Selector (Scroll View)

    #region Event: Item Selected

    public event EventHandler ItemSelected;

    #endregion Event: Item Selected




    public void asdf()
    {

    }



}

public class ValkyrieItem : MonoBehaviour
{
    ValkyrieMenuView view;

    [SerializeField] private Button button;

    private void Awake()
    {

    }

}

/*
    MVVM : View / View Model / Model
    - View : UI
    - Model : Data
    - View Model : Connector
*/