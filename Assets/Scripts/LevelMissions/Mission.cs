using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelMission
{
    public class Mission : MonoBehaviour
    {
        public int missionId;
        public string nameMission;
        public string descriptionMission;
        public MissionStatus missionStatus;

        protected virtual void ActivateMission()
        {
            missionStatus = MissionStatus.Active;
            MissionManager.Instance.ShowNewMissionUI(nameMission, descriptionMission);
        }

        protected virtual void DeactivateMission()
        {
            missionStatus = MissionStatus.Inactive;
            MissionManager.Instance.SetNameAndDescriptionMission("...", "...");
        }

        public virtual void MissionCompleated()
        {
            missionStatus = MissionStatus.Compleated;
            MissionManager.Instance.ShowMissionCompleatedUI(nameMission, descriptionMission);
            MissionManager.Instance.SetNameAndDescriptionMission("...", "...");
        }

        protected virtual void FailedMission()
        {
            missionStatus = MissionStatus.Failed;
            MissionManager.Instance.ShowMissionCompleatedUI(nameMission + "Failed", descriptionMission);
            MissionManager.Instance.SetNameAndDescriptionMission("...", "...");
        }

        public virtual void SetMissionStatus(MissionStatus missionStatus)
        {
            switch (missionStatus)
            {
                case MissionStatus.Active:
                    {
                        ActivateMission();
                        break;
                    }
                case MissionStatus.Inactive:
                    {
                        DeactivateMission();
                        break;
                    }
                case MissionStatus.Failed:
                    {
                        FailedMission();
                        break;
                    }
                case MissionStatus.Compleated:
                    {
                        MissionCompleated();
                        break;
                    }
            }
        }
    }
}