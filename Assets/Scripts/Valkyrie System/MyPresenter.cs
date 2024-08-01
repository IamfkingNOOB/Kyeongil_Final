using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyPresenter : MonoBehaviour
{
    #region UI 요소 (= View)

    [SerializeField] private TextMeshProUGUI Text_ValkyrieName;
    [SerializeField] private TextMeshProUGUI Text_SuitName;

    [SerializeField] private TextMeshProUGUI Text_Level;
    [SerializeField] private Image Image_Rank;
    [SerializeField] private Image Image_Traits;

    [SerializeField] private TextMeshProUGUI Text_WeaponName;
    [SerializeField] private Image Image_WeaponIcon;

    [SerializeField] private Image Image_StigmataTop;
    [SerializeField] private Image Image_StigmataMiddle;
    [SerializeField] private Image Image_StigmataBottom;

    #endregion UI 요소 (= View)

    #region MVP 디자인 패턴

    private MyModel _model;

    #endregion MVP 디자인 패턴

    private void OnEnable()
    {
        if (_model == null)
        {

        }
    }

    private void UpdateView()
    {

    }
}
