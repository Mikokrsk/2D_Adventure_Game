using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;
    [SerializeField] private VisualElement _gameMenu;
    [SerializeField] private InputAction _openGameMenu;
    // Start is called before the first frame update
    void Start()
    {
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.rootVisualElement.Q<Button>("QuitButton").clicked += Quit;
        _gameMenu = _uiDocument.rootVisualElement.Q<VisualElement>("GameMenuUI");
        _openGameMenu.Enable();
        _openGameMenu.performed += OpenMenu;
        _gameMenu.style.display = DisplayStyle.None;
    }

    private void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenMenu(InputAction.CallbackContext context)
    {
        if (_gameMenu.style.display == DisplayStyle.None)
        {
            _gameMenu.style.display = DisplayStyle.Flex;
            Debug.Log("1");
        }
        else
        {
            _gameMenu.style.display = DisplayStyle.None;
            Debug.Log("2");
        }

    }
}
