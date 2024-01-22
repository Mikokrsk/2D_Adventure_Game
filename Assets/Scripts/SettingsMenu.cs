using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    //[SerializeField] private static UIDocument _uiDocument;
    [SerializeField] private VisualElement _settingsMenu;

    void Start()
    {
        _settingsMenu = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("SettingsMenuUI");
        _settingsMenu.style.display = DisplayStyle.None;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("CloseSettingsMenuButton").clicked += CloseMenu;
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
