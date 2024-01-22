using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private VisualElement m_Healthbar;
    public float displayTime = 4.0f;
    [SerializeField] private VisualElement m_NonPlayerDialogue;
    [SerializeField] private float m_TimerDisplay;

    [SerializeField] public  UIDocument _uiDocument;
    [SerializeField] public GameMode _gameMode = GameMode.MainMenu;
    [SerializeField] private  GameObject _MainMenu;
    [SerializeField] private  GameObject _GameMenu;
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
        //_uiDocument = GetComponent<UIDocument>();
       // ChangeGameMode(GameMode.MainMenu);
    }

    private void Start()
    {
        if (_gameMode == GameMode.Game)
        {
            m_Healthbar = _uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
            SetHealthValue(1.0f);
            m_NonPlayerDialogue = _uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
            m_NonPlayerDialogue.style.display = DisplayStyle.None;

            m_TimerDisplay = -1.0f;
        }
    }

    private void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay < 0)
            {
                m_NonPlayerDialogue.style.display = DisplayStyle.None;
            }
        }
    }

    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    public void DisplayDialogue(string dialogText)
    {
        m_NonPlayerDialogue.Q<Label>("DialogText").text = dialogText;
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }

    public void ChangeGameMode(GameMode gameMode)
    {
        _gameMode = gameMode;

        if (_gameMode == GameMode.MainMenu)
        {            
            _MainMenu.active = true;
            _GameMenu.active = false;
        }
        else
        {
            _MainMenu.active = false;
            _GameMenu.active = true;
        }
    }
}

public enum GameMode
{
    Game,
    MainMenu
}