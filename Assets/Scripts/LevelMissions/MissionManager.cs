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
    public VisualElement missionCompleatedUI;
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
        missions.Clear();
        missions.AddRange(GetComponentsInChildren<Mission>());
        missionCompleatedUI.style.display = DisplayStyle.None;
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
        Invoke("HideMissionCompleatedUI", 2f);

    }
    public void HideMissionCompleatedUI()
    {
        compleatedMissionNameLabel.text = string.Empty;
        compleatedMissionDescriptionLabel.text = string.Empty;
        missionCompleatedUI.style.display = DisplayStyle.None;
    }


}
