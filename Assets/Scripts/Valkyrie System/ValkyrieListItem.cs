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

        Image_Portrait.sprite = valkyrie.Portrait;
        Image_Portrait.preserveAspect = true;

        Image_Rank.sprite = valkyrie.Rank.Icon;
        Text_Level.text = $"Lv.{valkyrie.Level}";
    }

    public void OnClick()
    {
        _model.ValkyrieName = _valkyrie.CharacterName;
        _model.Rank = _valkyrie.Rank.Icon;
        _model.SuitName = _valkyrie.SuitName;
        _model.Level = $"Lv.{_valkyrie.Level}";
        _model.WeaponName = _valkyrie.Weapon.Name;
        //_model.WeaponPrefab = _valkyrie._weapon.iconSprite;
        //_model.Stigmata_T = _valkyrie._stigmata_T.iconSprite;
        //_model.Stigmata_M = _valkyrie._stigmata_M.iconSprite;
        //_model.Stigmata_B = _valkyrie._stigmata_B.iconSprite;
    }
}
