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

        private void Start()
        {
            Invoke("ActivateMission", 1f);
        }
    }
}