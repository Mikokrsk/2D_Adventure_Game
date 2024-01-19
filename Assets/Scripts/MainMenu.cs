using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;
    [SerializeField] private SettingsMenu _settingsMenu;
    public static MainMenu Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.rootVisualElement.Q<Button>("OpenSettingsMenuButton").clicked += OpenSettingsMenu;
    }

    private void Start()
    {
        
    }
    public UIDocument GetUIDocument()
    {
        return _uiDocument;
    }

    private void OpenSettingsMenu()
    {
        _settingsMenu.OpenMenu();
    }
}
