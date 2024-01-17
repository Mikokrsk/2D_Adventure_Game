using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;
    [SerializeField] private VisualElement _closeButton;
    [SerializeField] private VisualElement _mainMenu;
    // Start is called before the first frame update
    void Start()
    {
         _uiDocument = GetComponent<UIDocument>();
        _closeButton = _uiDocument.rootVisualElement.Q<Button>("CloseButton");
        _mainMenu = _uiDocument.rootVisualElement.Q<VisualElement>("SettingMenu");
        _uiDocument.rootVisualElement.Q<Button>("CloseButton").clicked += () => { CloseMenu(); };
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CloseMenu()
    {
        Debug.Log("CloseMenu");
        _mainMenu.style.display = DisplayStyle.None;
    }
}
