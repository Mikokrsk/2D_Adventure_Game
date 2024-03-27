using LevelMission;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueAsset : ScriptableObject
{
    public DialogueSection[] dialogueSections;

    [System.Serializable]
    public struct DialogueSection
    {
        [TextArea]
        public string[] dialogue;
        public bool endAfterDialogue;
        public BranchPoint branchPoint;
    }
    [System.Serializable]
    public struct BranchPoint
    {
        [TextArea]
        public string question;
        public Answer[] answers;
    }
    [System.Serializable]
    public struct Answer
    {
        public string answerLabel;
        public MissionEvent[] missionEvents;
        public int nextDialogueSection;
    }
    [System.Serializable]
    public struct MissionEvent
    {
        public int missionId;
        public MissionStatus missionStatus;
    }
}