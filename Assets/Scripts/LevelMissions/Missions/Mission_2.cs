using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelMission
{
    public class Mission_2 : Mission
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] GameObject _enemy;
        [SerializeField] Transform _enemySpawnPosition;
        public void ActivateMission()
        {
            isMissionActive = true;
            MissionManager.Instance.SetNameAndDescriptionMission(nameMission, descriptionMission);
            PrintMission();
            _enemy = Instantiate(_enemy, _enemySpawnPosition);
        }

        private void DeactivateMission()
        {
            isMissionActive = false;
            MissionManager.Instance.SetNameAndDescriptionMission("...", "...");
            PrintMission();
            Destroy(this);
        }
        private void Update()
        {
            if (isMissionActive)
            {
                if (IsMissionCompleated())
                {
                    DeactivateMission();
                }
            }
        }

        private bool IsMissionCompleated()
        {
            if (_enemy != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}