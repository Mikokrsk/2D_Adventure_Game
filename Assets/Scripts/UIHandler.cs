using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    //(TODO):Dialog script
    [SerializeField] private VisualElement _HealthbarUI;
    [SerializeField] private float displayTime = 4.0f;
    [SerializeField] private VisualElement _NonPlayerDialogueUI;
    [SerializeField] private float _TimerDisplay;

    [SerializeField] public UIDocument _uiDocument;
    [SerializeField] public GameMode _gameMode = GameMode.MainMenu;
    [SerializeField] private GameObject _MainMenu;
    [SerializeField] private GameObject _GameMenu;
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
        if (_gameMode == GameMode.Game)
        {
            _HealthbarUI = _uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
            SetHealthValue(1.0f);
            _NonPlayerDialogueUI = _uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
            _NonPlayerDialogueUI.style.display = DisplayStyle.None;

            _TimerDisplay = -1.0f;
        }
        ChangeGameMode(GameMode.MainMenu);
    }

    private void Update()
    {
        if (_TimerDisplay > 0)
        {
            _TimerDisplay -= Time.deltaTime;
            if (_TimerDisplay < 0)
            {
                _NonPlayerDialogueUI.style.display = DisplayStyle.None;
            }
        }
    }

    public void SetHealthValue(float percentage)
    {
        _HealthbarUI.style.width = Length.Percent(100 * percentage);
    }

    public void DisplayDialogue(string dialogText)
    {
        _NonPlayerDialogueUI.Q<Label>("DialogText").text = dialogText;
        _NonPlayerDialogueUI.style.display = DisplayStyle.Flex;
        _TimerDisplay = displayTime;
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
        _MainMenu.SetActive(active);
    }

    public void SetGameMenuActive(bool active)
    {
        _GameMenu.SetActive(active);
    }
}

public enum GameMode
{
    Game,
    MainMenu
}