using LevelMission;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private List<Mission> missions = new List<Mission>();
    // Start is called before the first frame update
    void Start()
    {
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
}
