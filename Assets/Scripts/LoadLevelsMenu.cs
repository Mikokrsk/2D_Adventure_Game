using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadLevelsMenu : MonoBehaviour
{
    [SerializeField] private VisualElement _loadLevelsMenuUI;
    [SerializeField] private List<Action> _loadLevelsButtons;

    void Awake()
    {
        _loadLevelsMenuUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("LevelsMenuUI");
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>($"CloseLevelsMenuButton").clickable.clicked += CloseLoadLevelsMenuUI;
        for (int i = 1; ; i++)
        {
            if (UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>($"LoadLevelButton{i}") != null)
            {
                var button = UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>($"LoadLevelButton{i}").clickable;
                button.clickedWithEventInfo += LoadLevel;
            }
            else
            {
                break;
            }
        }
    }

    private void LoadLevel(EventBase obj)
    {
        var button = (Button)obj.target;
        button.Focus();
        var buttonName = button.name.Replace("LoadLevelButton", "");
        var id = Int32.Parse(buttonName);

        if (id < SceneManager.sceneCountInBuildSettings)
        {
            UIHandler.Instance.ChangeGameMode(GameMode.Game);
            SceneManager.LoadScene(id);
        }
        else
        {
            Debug.Log("Don't found this level");
        }
    }

    public void OpenLoadLevelsMenuUI()
    {
        _loadLevelsMenuUI.style.display = DisplayStyle.Flex;
    }

    public void CloseLoadLevelsMenuUI()
    {
        _loadLevelsMenuUI.style.display = DisplayStyle.None;
    }

}
