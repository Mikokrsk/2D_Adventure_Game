using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private VisualElement _settingsMenuUI;

    void Start()
    {
        _settingsMenuUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("SettingsMenuUI");
        _settingsMenuUI.style.display = DisplayStyle.None;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("CloseSettingsMenuButton").clicked += CloseSettingsMenuUI;
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
