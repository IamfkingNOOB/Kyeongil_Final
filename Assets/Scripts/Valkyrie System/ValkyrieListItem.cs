using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 발키리 화면에서, 발키리의 목록을 보여주는 스크롤 뷰 안의 아이템을 관리하는 클래스입니다.
/// </summary>
public class ValkyrieListItem : MonoBehaviour
{
    // 아이템이 보여줄 UI 요소
    [SerializeField] private Button Button_Item;
    [SerializeField] private Image Image_Portrait;
    [SerializeField] private Image Image_Rank;
    [SerializeField] private TextMeshProUGUI Text_Level;

    // 아이템이 가질 정보
    private ValkyrieMenuModel _model; // 발키리 화면의 모델(UI)
    private ValkyrieData _valkyrie; // 각 아이템이 가지는 발키리 정보

    // 생성할 때 호출하여, 각종 정보를 초기화합니다.
    public void Initialize(ValkyrieMenuModel model, ValkyrieData valkyrie)
    {
        _model = model;
        _valkyrie = valkyrie;

        Image_Portrait.sprite = valkyrie.Portrait;
        Image_Portrait.preserveAspect = true;

        Image_Rank.sprite = SetRankSprite(valkyrie.Rank);
        Text_Level.text = $"Lv.{valkyrie.Level}";
    }

    // 클릭 이벤트; 모델에 클릭한 발키리의 정보를 전달합니다.
    public void OnClick()
    {
        _model.SelectedValkyrie = _valkyrie;

        _model.CharacterName = _valkyrie.CharacterName;
        _model.Rank = SetRankSprite(_valkyrie.Rank);
        _model.SuitName = _valkyrie.SuitName;
        _model.Level = $"Lv.{_valkyrie.Level}";
        _model.WeaponName = _valkyrie.WeaponID.Name;
        _model.WeaponIcon = _valkyrie.WeaponID.Icon;
        _model.StigmataTop = _valkyrie.StigmataTopID.Icon;
        _model.StigmataMiddle = _valkyrie.StigmataMiddleID.Icon;
        _model.StigmataBottom = _valkyrie.StigmataBottomID.Icon;
    }

    // 랭크(Rank)의 이미지를 값에 맞게 가져와 반환합니다.
    private Sprite SetRankSprite(int rankID)
    {
        Sprite rankSprite = null;

        switch (rankID)
        {
            case 1: // B
                rankSprite = Resources.Load<Sprite>("");
                break;
            case 2: // A
                break;
            case 3: // S
                break;
            case 4: // S1
                break;
            case 5: // S2
                break;
            case 6: // S3
                break;
            case 7: // SS
                break;
            case 8: // SS1
                break;
            case 9: // SS2
                break;
            case 10: // SS3
                break;
            case 11: // SSS
                break;
            default:
                break;
        }

        return rankSprite;
    }
}
