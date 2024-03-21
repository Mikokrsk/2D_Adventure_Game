using LevelMission;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class MissionManager : MonoBehaviour
{
    public List<Mission> missions = new List<Mission>();
    public Label nameMissionLabel;
    public Label missionDescriptionLabel;
    public Label compleatedMissionNameLabel;
    public Label compleatedMissionDescriptionLabel;
    public Label newMissionNameLabel;
    public Label newMissionDescriptionLabel;
    public VisualElement missionCompleatedUI;
    public VisualElement newMissionUI;
    [SerializeField] private float _hideMissionCompleatedUIAfterDelay;
    [SerializeField] private float _hideNewMissionUIAfterDelay;
    // Start is called before the first frame update
    public static MissionManager Instance { get; private set; }

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
        nameMissionLabel = UIHandler.Instance._uiDocument.rootVisualElement.Q<Label>("MissionNameLabel");
        missionDescriptionLabel = UIHandler.Instance._uiDocument.rootVisualElement.Q<Label>("MissionDescriptionLabel");

        missionCompleatedUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("MissionCompleatedUI");
        compleatedMissionNameLabel = UIHandler.Instance._uiDocument.rootVisualElement.Q<Label>("CompleatedMissionNameLabel");
        compleatedMissionDescriptionLabel = UIHandler.Instance._uiDocument.rootVisualElement.Q<Label>("CompleatedMissionDescriptionLabel");

        newMissionUI = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("NewMissionUI");
        newMissionNameLabel = UIHandler.Instance._uiDocument.rootVisualElement.Q<Label>("NewMissionNameLabel");
        newMissionDescriptionLabel = UIHandler.Instance._uiDocument.rootVisualElement.Q<Label>("NewMissionDescriptionLabel");

        missions.Clear();
        missions.AddRange(GetComponentsInChildren<Mission>());
        missionCompleatedUI.style.display = DisplayStyle.None;
        newMissionUI.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*        foreach (var mission in missions)
                {
                    if (mission.isMissionCompleated)
                    {
                        mission.PrintMission();
                    }
                }*/
    }

    public void SetNameAndDescriptionMission(string name, string description)
    {
        nameMissionLabel.text = name;
        missionDescriptionLabel.text = description;
    }
    public void ShowMissionCompleatedUI(string missionName, string missionDescription)
    {
        compleatedMissionNameLabel.text = missionName;
        compleatedMissionDescriptionLabel.text = missionDescription;
        missionCompleatedUI.style.display = DisplayStyle.Flex;
        Invoke("HideMissionCompleatedUI", _hideMissionCompleatedUIAfterDelay);
    }
    public void HideMissionCompleatedUI()
    {
        compleatedMissionNameLabel.text = string.Empty;
        compleatedMissionDescriptionLabel.text = string.Empty;
        missionCompleatedUI.style.display = DisplayStyle.None;
    }
    public void ShowNewMissionUI(string missionName, string missionDescription)
    {
        SetNameAndDescriptionMission(missionName, missionDescription);
        newMissionNameLabel.text = missionName;
        newMissionDescriptionLabel.text = missionDescription;
        newMissionUI.style.display = DisplayStyle.Flex;
        Invoke("HideNewMissionUI", _hideNewMissionUIAfterDelay);
    }
    public void HideNewMissionUI()
    {
        newMissionNameLabel.text = string.Empty;
        newMissionDescriptionLabel.text = string.Empty;
        newMissionUI.style.display = DisplayStyle.None;
    }

}