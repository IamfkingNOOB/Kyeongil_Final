using UnityEngine;
using UnityEngine.UIElements;

public class MainView : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset m_ListEntryTemplate; // Entry UI

    void OnEnable()
    {
        // The UXML is already instantiated by the UIDocument component
        UIDocument uiDocument = GetComponent<UIDocument>();

        // Initialize the character list controller
        CharacterListController characterListController = new CharacterListController();
        characterListController.InitializeCharacterList(uiDocument.rootVisualElement, m_ListEntryTemplate);
    }
}