using UnityEngine;
using UnityEngine.UIElements;

public class ValkyrieUI : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset _valkyrieListViewItemTemplate; // 발키리의 목록을 보여주는 리스트 뷰(List View) 안의 항목 UXML

    // 활성화할 때,
    private void OnEnable()
    {
        // UIDocument 컴포넌트를 찾아,
        if (TryGetComponent(out UIDocument uiDocument))
        {
            // UI를 조작하는 클래스를 생성하여, UI를 초기화한다.
            ValkyrieUIController uiController = new ValkyrieUIController(uiDocument.rootVisualElement, _valkyrieListViewItemTemplate);
            uiController.Initialize(uiDocument.rootVisualElement, _valkyrieListViewItemTemplate);
        }
    }
}
