using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameMenu : MonoBehaviour
{
    //[SerializeField] private UIDocument _uiDocument;
    [SerializeField] private VisualElement _gameMenu;
    [SerializeField] private InputAction _openGameMenu;

    private void Start()
    {
        //if(UIHandler.Instance._uiDocument == null)
        //_uiDocument = UIHandler.Instance._uiDocument;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("QuitButton").clicked += Quit;
        _gameMenu = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("GameMenuUI");
        _openGameMenu.Enable();
        _openGameMenu.performed += OpenMenu;
        _gameMenu.style.display = DisplayStyle.None;
    }

    private void Quit()
    {
        UIHandler.Instance.ChangeGameMode(GameMode.MainMenu);
        SceneManager.LoadScene(0);
    }

    public void OpenMenu(InputAction.CallbackContext context)
    {
        if (_gameMenu.style.display == DisplayStyle.None)
        {
            _gameMenu.style.display = DisplayStyle.Flex;
        }
        else
        {
            _gameMenu.style.display = DisplayStyle.None;
        }
    }
}
