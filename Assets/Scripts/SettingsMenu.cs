using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private VisualElement _settingsMenuUI;
    [SerializeField] private List<Button> _settingsMenuButtons;
    void Start()
    {
        _settingsMenuUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("SettingsMenuUI");
        _settingsMenuUI.style.display = DisplayStyle.None;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("CloseSettingsMenuButton").clicked += CloseSettingsMenuUI;
        _settingsMenuButtons = UIHandler.Instance._uiDocument.rootVisualElement.Query<Button>("OpenSettingsMenuButton").ToList();
        foreach (var button in _settingsMenuButtons)
        {
            button.clicked += OpenSettingsMenuUI;
        }
    }

    public void OpenSettingsMenuUI()
    {
        _settingsMenuUI.style.display = DisplayStyle.Flex;
    }

    public void CloseSettingsMenuUI()
    {
        _settingsMenuUI.style.display = DisplayStyle.None;
    }
}
