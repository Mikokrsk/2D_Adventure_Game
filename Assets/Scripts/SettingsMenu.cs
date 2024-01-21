using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;
    [SerializeField] private VisualElement _settingsMenu;

    void Start()
    {
        _uiDocument = MainMenu.Instance.GetUIDocument();
        _settingsMenu = _uiDocument.rootVisualElement.Q<VisualElement>("SettingsMenuUI");
        _uiDocument.rootVisualElement.Q<Button>("CloseSettingsMenuButton").clicked += CloseMenu;
    }

    public void OpenMenu()
    {
        _settingsMenu.style.display = DisplayStyle.Flex;
    }

    public void CloseMenu()
    {
        _settingsMenu.style.display = DisplayStyle.None;
    }
}
