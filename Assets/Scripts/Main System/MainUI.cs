using UnityEngine;
using UnityEngine.UIElements;

/*
 * 1. Valkyrie
 *      - 발키리(캐릭터) 파티를 구성할 수 있다.
 *      - 한 파티에 최대 3명의 발키리가 참가할 수 있다.
 *      - 
 * 
 * 2. Equipment
 *      - 발키리에 장비를 장착시킬 수 있다.
 *      - 무기와 성흔 3개를 장착시킬 수 있다.
 *      
 * 3. Battle
 *      - 구성한 파티가 전투에 참여한다.
 * 
 * 4. Gacha
 *      - 발키리와 장비를 뽑을 수 있다.
 *      
 * 
 */

public class MainUI : MonoBehaviour
{
    // UI Toolkit; UXML의 UI 요소에 접근하기 위한 Root Visual Element
    private VisualElement root;

    // UI Elements; UI Builder(UXML)에서 작업하여 생성한 UI 요소들
    private Button _valkyrieButton; // 발키리(캐릭터)
    private Button _battleButton; // 전투
    private Button _equipmentButton; // 장비
    private Button _gachaButton; // 뽑기(가챠)

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        // Q<>("_name")으로 접근할 수 있다.
        _battleButton = root.Q<Button>("Battle_Button");
        _battleButton.clicked += () => Debug.Log("Battle Button Clicked!");
    }
}
