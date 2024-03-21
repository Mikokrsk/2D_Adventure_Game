using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace LevelMission
{
    public class Mission_2 : Mission
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] GameObject _enemy;
        [SerializeField] Transform _enemySpawnPosition;
        [SerializeField] Mission _mission1;
        public void ActivateMission()
        {
            isMissionActive = true;
            MissionManager.Instance.ShowNewMissionUI(nameMission, descriptionMission);
            // MissionManager.Instance.SetNameAndDescriptionMission(nameMission, descriptionMission);
            _enemy = Instantiate(_enemy, _enemySpawnPosition);
        }

        private void DeactivateMission()
        {
            isMissionActive = false;
            MissionManager.Instance.SetNameAndDescriptionMission("...", "...");

            if (isMissionCompleated)
            {
                MissionManager.Instance.ShowMissionCompleatedUI(nameMission, descriptionMission);
            }
            //  Destroy(this);
        }
        private void Update()
        {
            if (isMissionCompleated)
            {
                return;
            }
            if (isMissionActive)
            {
                IsMissionCompleated();
            }
            else
            {
                if (_mission1.isMissionCompleated && !isMissionActive && MissionManager.Instance.missionCompleatedUI.style.display == DisplayStyle.None)
                {
                    ActivateMission();
                }
            }
        }

        private void IsMissionCompleated()
        {
            if (_enemy == null)
            {
                isMissionCompleated = true;
                DeactivateMission();
            }
        }
    }
}