using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;
    [SerializeField] private SettingsMenu _settingsMenu;
    [SerializeField] private LoadLevelsMenu _loadLevelsMenu;
    public static MainMenu Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.rootVisualElement.Q<Button>("OpenSettingsMenuButton").clicked += OpenSettingsMenu;
        _uiDocument.rootVisualElement.Q<Button>("StartButton").clicked += StartGame;
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

    private void StartGame()
    {
        _loadLevelsMenu.OpenMenu();
    }
}
