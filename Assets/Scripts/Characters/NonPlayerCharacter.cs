using LevelMission;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    [SerializeField] private DialogueAsset _dialogueAsset;
    [SerializeField] private int _currentDialogueSection = 0;
    [SerializeField] private NPCDialogueManager _dialogueManager;

    public void Interaction()
    {
        _dialogueManager.StartDialogue(_dialogueAsset, _currentDialogueSection);
    }
}