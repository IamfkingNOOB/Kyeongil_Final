using UnityEngine;
using UnityEngine.UIElements;

public class MainView : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset m_ListEntryTemplate; // Entry UI

    UIDocument uiDocument;

    private void Awake()
    {
        // The UXML is already instantiated by the UIDocument component
        uiDocument = GetComponent<UIDocument>();

        
    }

    void OnEnable()
    {
        // Initialize the character list controller
        CharacterListController characterListController = new CharacterListController();
        characterListController.InitializeCharacterList(uiDocument.rootVisualElement, m_ListEntryTemplate);
    }
}