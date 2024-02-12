using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    [SerializeField] public UIDocument _uiDocument;
    [SerializeField] public GameMode _gameMode = GameMode.MainMenu;
    [SerializeField] private GameObject _MainMenuUIObject;
    [SerializeField] private GameObject _GameUIObject;
    public static UIHandler Instance { get; private set; }

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

    private void Start()
    {
        ChangeGameMode(GameMode.MainMenu);
    }

    public void ChangeGameMode(GameMode gameMode)
    {
        _gameMode = gameMode;

        if (_gameMode == GameMode.MainMenu)
        {
            SetMainMenuActive(true);
            SetGameMenuActive(false);
        }
        else
        {
            SetMainMenuActive(false);
            SetGameMenuActive(true);
        }
    }

    public void SetMainMenuActive(bool active)
    {
        _MainMenuUIObject.SetActive(active);
    }

    public void SetGameMenuActive(bool active)
    {
        _GameUIObject.SetActive(active);
    }
}

public enum GameMode
{
    Game,
    MainMenu
}