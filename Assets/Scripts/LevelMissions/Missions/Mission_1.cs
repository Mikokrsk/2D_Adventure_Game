using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace LevelMission
{
    public class Mission_1 : Mission
    {
        [SerializeField] private PlayerController _playerController;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                if (collision.CompareTag("Player") && missionStatus == MissionStatus.Inactive)
                {
                    ActivateMission();
                }
            }
        }
    }
}