using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMission
{
    public class Mission : MonoBehaviour
    {
        public string nameMission;
        public string descriptionMission;
        public bool isMissionCompleated;
        public bool isMissionActive;

        public void PrintMission()
        {
            Debug.Log(nameMission);
            Debug.Log(descriptionMission);
            Debug.Log(isMissionCompleated);
        }
    }
}