using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private VisualElement _mainMenuUI;
    [SerializeField] private SettingsMenu _settingsMenu;
    [SerializeField] private LoadLevelsMenu _loadLevelsMenu;
    public static MainMenu Instance { get; private set; }

    private void OnEnable()
    {
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("OpenSettingsMenuButton").clicked += OpenSettingsMenu;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("StartButton").clicked += OpenLoadLevelsMenu;
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("ExitTheGameButton").clicked += ExitTheGame;
        }
        else
        {
            UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("ExitTheGameButton").style.display = DisplayStyle.None;
        }
        _mainMenuUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("MainMenuUI");
        _mainMenuUI.style.display = DisplayStyle.None;
        OpenMainMenu();
    }

    private void OnDisable()
    {
        CloseMainMenuUI();
    }

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMainMenu()
    {
        _mainMenuUI.style.display = DisplayStyle.Flex;
    }

    private void OpenSettingsMenu()
    {
        _settingsMenu.OpenSettingsMenuUI();
    }

    private void OpenLoadLevelsMenu()
    {
        _loadLevelsMenu.OpenLoadLevelsMenuUI();
    }

    private void CloseMainMenuUI()
    {
        _settingsMenu.CloseSettingsMenuUI();
        _loadLevelsMenu.CloseLoadLevelsMenuUI();
        _mainMenuUI.style.display = DisplayStyle.None;
    }

    private void ExitTheGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
