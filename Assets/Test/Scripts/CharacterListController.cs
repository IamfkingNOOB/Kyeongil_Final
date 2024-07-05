using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterListController
{
    // UXML template for list entries
    private VisualTreeAsset m_ListEntryTemplate;

    // UI element references
    private ListView m_CharacterList;
    private Label m_CharClassLabel;
    private Label m_CharNameLabel;
    private VisualElement m_CharPortrait;

    private List<CharacterData> m_AllCharacters;

    public void InitializeCharacterList(VisualElement root, VisualTreeAsset listElementTemplate)
    {
        EnumerateAllCharacters();

        // Store a reference to the template for the list entries
        m_ListEntryTemplate = listElementTemplate;

        // Store a reference to the character list element
        m_CharacterList = root.Q<ListView>("character-list"); // 왼쪽의 ListView

        // Store references to the selected character info elements
        m_CharClassLabel = root.Q<Label>("character-class"); // 오른쪽의 Label 1
        m_CharNameLabel = root.Q<Label>("character-name"); // 오른쪽의 Label 2
        m_CharPortrait = root.Q<VisualElement>("character-portrait"); // 오른쪽의 Label 3

        FillCharacterList();

        // Register to get a callback when an item is selected
        m_CharacterList.selectionChanged += OnCharacterSelected;
    }

    void EnumerateAllCharacters()
    {
        // Resources 폴더의 Characters 폴더에 접근하여, CharacterData 클래스를 가진 것을 전부 불러오고, List에 추가한다.
        m_AllCharacters = new List<CharacterData>();
        m_AllCharacters.AddRange(Resources.LoadAll<CharacterData>("Characters"));
    }

    void FillCharacterList()
    {
        // Set up a make item function for a list entry
        m_CharacterList.makeItem = () =>
        {
            Debug.Log("makeItem");

            // Instantiate the UXML template for the entry
            TemplateContainer newListEntry = m_ListEntryTemplate.Instantiate();

            // Instantiate a controller for the data
            CharacterListEntryController newListEntryLogic = new CharacterListEntryController();

            // Assign the controller script to the visual element
            newListEntry.userData = newListEntryLogic;

            // Initialize the controller script
            newListEntryLogic.SetVisualElement(newListEntry);

            // Return the root of the instantiated visual tree
            return newListEntry;
        };

        // Set up bind function for a specific list entry
        m_CharacterList.bindItem = (VisualElement item, int index) =>
        {
            Debug.Log("BindItem");

            // (item.userData as CharacterListEntryController)?.SetCharacterData(m_AllCharacters[index]);
        };

        // Set a fixed item height matching the height of the item provided in makeItem. 
        // For dynamic height, see the virtualizationMethod property.
        m_CharacterList.fixedItemHeight = 45;

        // Set the actual item's source list/array
        // m_CharacterList.itemsSource = m_AllCharacters;
    }

    void OnCharacterSelected(IEnumerable<object> selectedItems)
    {
        // Get the currently selected item directly from the ListView
        CharacterData selectedCharacter = m_CharacterList.selectedItem as CharacterData;

        // Handle none-selection (Escape to deselect everything)
        if (selectedCharacter == null)
        {
            // Clear
            m_CharClassLabel.text = "";
            m_CharNameLabel.text = "";
            m_CharPortrait.style.backgroundImage = null;

            return;
        }

        // Fill in character details
        m_CharClassLabel.text = selectedCharacter.Class.ToString();
        m_CharNameLabel.text = selectedCharacter.CharacterName;
        m_CharPortrait.style.backgroundImage = new StyleBackground(selectedCharacter.PortraitImage);
    }
}