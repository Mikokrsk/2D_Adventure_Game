using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCDialogueManager : MonoBehaviour
{
    [SerializeField] private VisualElement _dialogueBox;
    [SerializeField] private Label _dialogueLabel;
    //  [SerializeField] private float _TimerDisplay;

    void Start()
    {
        _dialogueBox = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        _dialogueLabel = UIHandler.Instance._uiDocument.rootVisualElement.Q<Label>("DialogText");
        _dialogueBox.style.display = DisplayStyle.None;
        //  _TimerDisplay = -1.0f;
    }

    public void StartDialogue(DialogueAsset dialogueTree, int startSection)
    {
        ResetDialogueBox();
        // nameText.text = name + "...";
        _dialogueBox.style.display = DisplayStyle.Flex;
        // OnDialogueStarted?.Invoke();
        StartCoroutine(RunDialogue(dialogueTree, startSection));
    }

    public void ResetDialogueBox()
    {
        _dialogueBox.style.display = DisplayStyle.None;
    }

    IEnumerator RunDialogue(DialogueAsset dialogueTree, int section)
    {
        for (int i = 0; i < dialogueTree.dialogueSections[section].dialogue.Length; i++)
        {
            _dialogueLabel.text = dialogueTree.dialogueSections[section].dialogue[i];
            yield return new WaitForSeconds(3f);
            /*            while (skipLineTriggered == false)
                        {
                            yield return null;
                        }
                        skipLineTriggered = false;*/
        }
        if (dialogueTree.dialogueSections[section].endAfterDialogue)
        {
            // OnDialogueEnded?.Invoke();
            _dialogueBox.style.display = DisplayStyle.None;
            yield break;
        }

        /*

                dialogueText.text = dialogueTree.sections[section].branchPoint.question;
                ShowAnswers(dialogueTree.sections[section].branchPoint);

                while (answerTriggered == false)
                {
                    yield return null;
                }
                answerBox.SetActive(false);
                answerTriggered = false;

                StartCoroutine(RunDialogue(dialogueTree, dialogueTree.sections[section].branchPoint.answers[answerIndex].nextElement));*/
    }
    /*    public void DisplayDialogue(string dialogText)
        {
            _NonPlayerDialogueUI.Q<Label>("DialogText").text = dialogText;
            _NonPlayerDialogueUI.style.display = DisplayStyle.Flex;
            _TimerDisplay = _displayTime;
        }*/

    /* IEnumerator RunDialogue(DialogueAsset dialogueTree, int section)
     {
         for (int i = 0; i < dialogueTree.dialogueSections[section].dialogue.Length; i++)
         {
             dialogueText.text = dialogueTree.sections[section].dialogue[i];
             while (skipLineTriggered == false)
             {
                 yield return null;
             }
             skipLineTriggered = false;
         }

         if (dialogueTree.sections[section].endAfterDialogue)
         {
             OnDialogueEnded?.Invoke();
             dialogueBox.SetActive(false);
             yield break;
         }

         dialogueText.text = dialogueTree.sections[section].branchPoint.question;
         ShowAnswers(dialogueTree.sections[section].branchPoint);

         while (answerTriggered == false)
         {
             yield return null;
         }
         answerBox.SetActive(false);
         answerTriggered = false;

         StartCoroutine(RunDialogue(dialogueTree, dialogueTree.sections[section].branchPoint.answers[answerIndex].nextElement));
     }*/
}