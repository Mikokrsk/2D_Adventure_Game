using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
    [SerializeField] private VisualElement _HealthbarUI;
    [SerializeField] private float _displayTime = 4.0f;
    [SerializeField] private VisualElement _NonPlayerDialogueUI;
    [SerializeField] private VisualElement _gameUI;
    [SerializeField] private float _TimerDisplay;
    public static GameUI Instance { get; private set; }

    private void OnEnable()
    {
        _gameUI.style.display = DisplayStyle.Flex;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _HealthbarUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
            SetHealthValue(1.0f);
            _NonPlayerDialogueUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
            _gameUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("GameUI");
            _NonPlayerDialogueUI.style.display = DisplayStyle.None;
            _TimerDisplay = -1.0f;
        }
        else
        {
            Destroy(gameObject);
        }
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

    public void DisplayDialogue(string dialogText)
    {
        _NonPlayerDialogueUI.Q<Label>("DialogText").text = dialogText;
        _NonPlayerDialogueUI.style.display = DisplayStyle.Flex;
        _TimerDisplay = _displayTime;
    }

    public void SetHealthValue(float percentage)
    {
        _HealthbarUI.style.width = Length.Percent(100 * percentage);
    }

    private void OnDisable()
    {
        _gameUI.style.display = DisplayStyle.None;
    }
}
