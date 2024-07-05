using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ValkyrieUIController
{
    // 발키리의 목록을 보여주는 리스트 뷰(ListView) 안에 추가할 UI 요소
    private VisualTreeAsset _valkyrieItemTemplate;

    // 발키리 UI를 구성하는 UI 요소들
    private ListView _valkyrieListView; // 발키리의 목록을 보여주는 리스트 뷰
    private Label _valkyrieNameLabel; // 목록에서 선택한 발키리의 이름을 보여줄 레이블

    private List<Valkyrie> _valkyrieList; // 발키리의 전체 목록; UI에 보여주는 것이 아닌, 데이터를 가져와 사용하기 위한 공간
    private Dictionary<string, Valkyrie> _valkyrieDictionary;

    public ValkyrieUIController(VisualElement root, VisualTreeAsset valkyrieItemTemplate)
    {
    }

    // 
    public void Initialize(VisualElement rootVisualElement, VisualTreeAsset valkyrieListViewItemTemplate)
    {
        // UI 요소들을 초기화합니다.
        InitializeUIElements(rootVisualElement);

        // 리스트 뷰의 항목을 초기화합니다.
        InitializeListViewItems(valkyrieListViewItemTemplate);
    }

    // UI 요소들을 초기화합니다.
    private void InitializeUIElements(VisualElement rootVisualElement)
    {
        _valkyrieListView = rootVisualElement.Q<ListView>("ValkyrieListView");
        _valkyrieNameLabel = rootVisualElement.Q<Label>("Valkyrie_Name");
    }

    // 리스트 뷰의 항목을 초기화합니다.
    private void InitializeListViewItems(VisualTreeAsset valkyrieListViewItemTemplate)
    {
        //_valkyrieListView.makeItem = () =>
        //{
        //    TemplateContainer newListItem = valkyrieListViewItemTemplate.Instantiate();

        //    newListItem.userData = new object();
        //};

        // _valkyrieListView.hierarchy.Add(valkyrieListViewItemTemplate.Instantiate());

        int[] testIntArray = new int[100];

        for (int i = 0; i < testIntArray.Length; i++)
        {
            testIntArray[i] = i;
        }

        List<int> testIntList = new List<int>();

        _valkyrieListView.itemsSource = testIntArray;

        _valkyrieListView.makeItem = () =>
        {
            Debug.Log("makeItem");

            var a = valkyrieListViewItemTemplate.Instantiate();

            return a;
        };

        _valkyrieListView.bindItem = (a, b) =>
        {
            Debug.Log("bindItem");
        };



    }



    public void InitializeValkyrieList()
    {
        _valkyrieDictionary = new Dictionary<string, Valkyrie>();
    }

    // 모든 발키리의 정보를 가져옵니다.
    private Valkyrie[] GetAllValkyries()
    {
        Valkyrie[] allValkyries = Resources.LoadAll<Valkyrie>("Databases/Valkyries");
        return allValkyries;
    }

    
}