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
        [SerializeField] private Mission_2 _mission_2;
        private void Start()
        {
            ActivateMission();
        }
        private void ActivateMission()
        {
            isMissionActive = true;
            MissionManager.Instance.SetNameAndDescriptionMission(nameMission, descriptionMission);
            _playerController.talkAction.performed += IsMissionCompleated;
            PrintMission();
        }

        private void DeactivateMission()
        {
            isMissionActive = false;
            MissionManager.Instance.SetNameAndDescriptionMission("...", "...");
            _playerController.talkAction.performed -= IsMissionCompleated;
            PrintMission();
            _mission_2.ActivateMission();
            Destroy(this);
        }

        private void IsMissionCompleated(InputAction.CallbackContext context)
        {
            var hit = _playerController.FindFriend();

            if (hit.collider != null)
            {
                if (_playerController.FindFriend().collider.name == "NPC_Frog")
                {
                    isMissionCompleated = true;
                    DeactivateMission();
                }
            }
        }
    }
}