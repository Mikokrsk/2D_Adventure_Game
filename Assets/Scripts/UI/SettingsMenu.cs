using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private VisualElement _settingsMenuUI;
    [SerializeField] private Toggle _fullScreenToggle;
    [SerializeField] private Button _applyButton;
    [SerializeField] private DropdownField _resolutionDropdownField;
    [SerializeField] private DropdownField _qualityDropdownField;
    [SerializeField] private List<Button> _settingsMenuButtons;
    [SerializeField] public static SettingsMenu Instance;

    public bool IsFullsreenMode
    {
        get
        {
            return _fullScreenToggle.value;
        }
        set
        {
            ChangeScreenMode(value);
        }
    }
    public int ResolutionIndex
    {
        get
        {
            return _resolutionDropdownField.index;
        }
        set
        {
            _resolutionDropdownField.index = value;
        }
    }
    public int QualityIndex
    {
        get
        {
            return _qualityDropdownField.index;
        }
        set
        {
            _qualityDropdownField.index = value;
        }
    }
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
    void Start()
    {
        _settingsMenuUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("SettingsMenuUI");
        _settingsMenuUI.style.display = DisplayStyle.None;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("CloseSettingsMenuButton").clicked += CloseSettingsMenuUI;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("ApplySettingsMenuButton").clicked += ApplySettings;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("SaveSettingsMenuButton").clicked += SaveSettings;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("LoadSettingsMenuButton").clicked += LoadSettings;
        _fullScreenToggle = UIHandler.Instance._uiDocument.rootVisualElement.Q<Toggle>("FullScreenToggle");
        _fullScreenToggle.value = true;
        _fullScreenToggle.RegisterCallback<ClickEvent>(ChangeScreenMode);

        _resolutionDropdownField = UIHandler.Instance._uiDocument.rootVisualElement.Q<DropdownField>("ResolutionDropdownField");
        _resolutionDropdownField.choices.Clear();
        List<Resolution> resolutions = new List<Resolution>();
        resolutions.AddRange(Screen.resolutions);
        resolutions.Reverse();
        foreach (var res in resolutions)
        {
            _resolutionDropdownField.choices.Add($"{res.width}x{res.height}:{res.refreshRateRatio}");
        }
        _resolutionDropdownField.value = _resolutionDropdownField.choices.First();

        _qualityDropdownField = UIHandler.Instance._uiDocument.rootVisualElement.Q<DropdownField>("QualityDropdownField");
        _qualityDropdownField.choices.Clear();

        List<string> qualityList = new List<string>();
        qualityList.AddRange(QualitySettings.names);
        foreach (var quality in qualityList)
        {
            _qualityDropdownField.choices.Add($"{quality}");
        }
        _qualityDropdownField.value = _qualityDropdownField.choices.First();

        _settingsMenuButtons = UIHandler.Instance._uiDocument.rootVisualElement.Query<Button>("OpenSettingsMenuButton").ToList();
        foreach (var button in _settingsMenuButtons)
        {
            button.clicked += OpenSettingsMenuUI;
        }

        LoadSettings();
    }

    public void OpenSettingsMenuUI()
    {
        _settingsMenuUI.style.display = DisplayStyle.Flex;
    }

    public void CloseSettingsMenuUI()
    {
         _settingsMenuUI.style.display = DisplayStyle.None;
        //LoadSettings();
    }

    public void ChangeScreenMode(ClickEvent evt)
    {
        if (_fullScreenToggle.value)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
    public void ChangeScreenMode(bool value)
    {
        _fullScreenToggle.value = value;
        if (value)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void ApplySettings()
    {
        var res = _resolutionDropdownField.value.Split('x', ':');
        Screen.SetResolution(Int32.Parse(res[0]), Int32.Parse(res[1]), _fullScreenToggle.value);
        for (int i = 0; i < _qualityDropdownField.choices.Count; i++)
        {
            if (_qualityDropdownField.value == _qualityDropdownField.choices[i])
            {
                QualitySettings.SetQualityLevel(i);
                break;
            }
        }

       // SaveSettings();
    }

    private void SaveSettings()
    {
        Save.SaveSystem.Instance.Save("Assets/Saves/", "settingsSave", ".data");
    }

    private void LoadSettings()
    {
        Save.SaveSystem.Instance.Load("Assets/Saves/", "settingsSave", ".data");
    }
}