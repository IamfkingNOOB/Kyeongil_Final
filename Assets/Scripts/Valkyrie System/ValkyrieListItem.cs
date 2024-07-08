using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValkyrieListItem : MonoBehaviour
{
    [SerializeField] private Button Button_Item;
    [SerializeField] private Image Image_Portrait;
    [SerializeField] private Image Image_Rank;
    [SerializeField] private TextMeshProUGUI Text_Level;

    private ValkyrieMenuModel _model;
    private Valkyrie _valkyrie;

    public void Initialize(ValkyrieMenuModel model, Valkyrie valkyrie)
    {
        _model = model;
        _valkyrie = valkyrie;

        Debug.Log(valkyrie._character_Name);

        Image_Portrait.sprite = valkyrie._portrait;
        Image_Portrait.preserveAspect = true;

        Image_Rank.sprite = valkyrie._rank._iconSprite;
        Text_Level.text = $"Lv.{valkyrie._level}";
    }

    public void OnClick()
    {
        Debug.Log(_valkyrie._character_Name);

        _model.ValkyrieName = _valkyrie._character_Name;
        _model.Rank = _valkyrie._rank._iconSprite;
        _model.SuitName = _valkyrie._suitName;
        _model.Level = $"Lv.{_valkyrie._level}";
        _model.WeaponName = _valkyrie._weapon.name;
        //_model.WeaponPrefab = _valkyrie._weapon.iconSprite;
        //_model.Stigmata_T = _valkyrie._stigmata_T.iconSprite;
        //_model.Stigmata_M = _valkyrie._stigmata_M.iconSprite;
        //_model.Stigmata_B = _valkyrie._stigmata_B.iconSprite;
    }
}
