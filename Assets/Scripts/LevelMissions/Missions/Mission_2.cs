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
        [SerializeField] GameObject _enemyPrefab;
        [SerializeField] Transform _enemySpawnPosition;

        protected override void ActivateMission()
        {
            base.ActivateMission();
            _enemy = Instantiate(_enemyPrefab, _enemySpawnPosition);
        }
        protected override void FailedMission()
        {
            base.FailedMission();
            if (_enemy != null)
            {
                Destroy(_enemy);
            }
        }

        private void Update()
        {
            if (missionStatus == MissionStatus.Active)
            {
                IsMissionCompleated();
            }
        }

        private void IsMissionCompleated()
        {
            if (_enemy == null)
            {
                SetMissionStatus(MissionStatus.Compleated);
            }
        }
    }
}