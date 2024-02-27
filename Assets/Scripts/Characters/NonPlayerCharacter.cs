using LevelMission;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    [SerializeField] private string _DialogText = "...";

    public void DisplayDialogue()
    {
        GameUI.Instance.DisplayDialogue(_DialogText);
    }

}