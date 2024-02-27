using LevelMission;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private List<Mission> missions = new List<Mission>();
    public Label nameMissionLabel;
    public Label missionDescriptionLabel;
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
        missions.Clear();
        missions.AddRange(GetComponentsInChildren<Mission>());
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
}
