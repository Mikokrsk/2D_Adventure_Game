using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private VisualElement _gameMenuUI;
    [SerializeField] private VisualElement _missionTabUI;
    [SerializeField] private InputAction _menuToggleAction;
    [SerializeField] private InputAction _showMissionTabAction;
    [SerializeField] public static GameMenu Instance;

    [SerializeField] private float afterDelay;
    [SerializeField] private float delay;
    [SerializeField] private float opacityValue;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("QuitButton").clicked += Quit;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("SaveGameButton").clicked += SaveGame;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("LoadGameButton").clicked += LoadGame;
        _gameMenuUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("GameMenuUI");
        _missionTabUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("MissionTab");
        _menuToggleAction.Enable();
        _showMissionTabAction.Enable();
        _menuToggleAction.performed += ToggleGameMenu;
        _showMissionTabAction.performed += ShowMissionTab;
        _gameMenuUI.style.display = DisplayStyle.None;
        _missionTabUI.style.display = DisplayStyle.None;
    }

    private void OnDisable()
    {
        CloseGameMenuUI();
    }

    private void Quit()
    {
        UIHandler.Instance.ChangeGameMode(GameMode.MainMenu);
        SceneManager.LoadScene(0);
    }

    public void ToggleGameMenu(InputAction.CallbackContext context)
    {
        if (_gameMenuUI.style.display == DisplayStyle.None)
        {
            OpenMenuGameMenuUI();
        }
        else
        {
            CloseGameMenuUI();
        }
    }

    public void ShowMissionTab(InputAction.CallbackContext context)
    {
        if (_missionTabUI.style.display == DisplayStyle.None)
        {
            _missionTabUI.style.display = DisplayStyle.Flex;
            Invoke("SmoothCloseMissionTab", afterDelay);
        }
        else
        {
            CloseMissionTab();
        }
    }

    public void CloseMissionTab()
    {
        _missionTabUI.style.display = DisplayStyle.None;
        _missionTabUI.style.opacity = new StyleFloat(1f);
    }

    public void SmoothCloseMissionTab()
    {
        var opacity = _missionTabUI.style.opacity.value;
        _missionTabUI.style.opacity = new StyleFloat(opacity - opacityValue);

        if (_missionTabUI.style.opacity.value > 0 && _missionTabUI.style.display == DisplayStyle.Flex)
        {
            Invoke("SmoothCloseMissionTab", delay);
        }
        else
        {
            CloseMissionTab();
        }
    }

    public void OpenMenuGameMenuUI()
    {
        _gameMenuUI.style.display = DisplayStyle.Flex;
    }

    public void CloseGameMenuUI()
    {
        _gameMenuUI.style.display = DisplayStyle.None;
    }

    public void SaveGame()
    {
        Save.SaveSystem.Instance.Save("Assets/Saves/", "GameSave", ".data");
    }
    public void LoadGame()
    {
        Save.SaveSystem.Instance.Load("Assets/Saves/", "GameSave", ".data");
    }
}