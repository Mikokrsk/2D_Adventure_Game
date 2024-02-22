using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private VisualElement _gameMenuUI;
    [SerializeField] private InputAction _menuToggleAction;
    [SerializeField] public static GameMenu Instance;

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
        _menuToggleAction.Enable();
        _menuToggleAction.performed += ToggleGameMenu;
        _gameMenuUI.style.display = DisplayStyle.None;
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