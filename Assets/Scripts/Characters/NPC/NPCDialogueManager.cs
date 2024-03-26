using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;


public class NPCDialogueManager : MonoBehaviour
{
    // [Header("Dialogue")]
    [SerializeField] private DialogueAsset _currentDialogueTree;
    private VisualElement _dialogueBox;
    private Label _dialogueLabel;

    //  [Header("Answers")]
    [SerializeField] private StyleSheet _answersStyleSheet;
    private VisualElement _answersBox;
    private ScrollView _answersScrollView;

    void Start()
    {
        _dialogueBox = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        _answersBox = UIHandler.Instance._uiDocument.rootVisualElement.Q<VisualElement>("AnswersBox");
        _answersScrollView = UIHandler.Instance._uiDocument.rootVisualElement.Q<ScrollView>("AnswersScrollView");
        _dialogueLabel = UIHandler.Instance._uiDocument.rootVisualElement.Q<Label>("DialogText");
        _dialogueBox.style.display = DisplayStyle.None;
        _answersBox.style.display = DisplayStyle.None;
    }

    public void StartDialogue(DialogueAsset dialogueTree, int startSection)
    {
        ResetDialogueBox();
        _currentDialogueTree = dialogueTree;
        _dialogueBox.style.display = DisplayStyle.Flex;
        StartCoroutine(RunDialogue(dialogueTree, startSection));
    }

    public void EndDialogue()
    {
        ResetDialogueBox();
        _dialogueBox.style.display = DisplayStyle.None;
    }

    public void ResetDialogueBox()
    {
        _answersBox.style.display = DisplayStyle.None;
        _currentDialogueTree = null;
        _answersScrollView.Clear();
    }

    IEnumerator RunDialogue(DialogueAsset dialogueTree, int section)
    {
        for (int i = 0; i < dialogueTree.dialogueSections[section].dialogue.Length; i++)
        {
            _dialogueLabel.text = dialogueTree.dialogueSections[section].dialogue[i];
            yield return new WaitForSeconds(3f);
        }
        if (dialogueTree.dialogueSections[section].endAfterDialogue)
        {
            _dialogueBox.style.display = DisplayStyle.None;
            EndDialogue();
            yield break;
        }
        if (!dialogueTree.dialogueSections[section].endAfterDialogue)
        {
            ShowAnswers(dialogueTree.dialogueSections[section].branchPoint.answers);
        }
    }

    public void ShowAnswers(DialogueAsset.Answer[] answers)
    {
        _answersBox.style.display = DisplayStyle.Flex;

        for (int i = 0; i < answers.Length; i++)
        {
            var answerButton = CreateAnswerButton(_currentDialogueTree, answers[i].answerLabel, answers[i].nextDialogueSection);
            _answersScrollView.Insert(i, answerButton);
        }
    }

    public Button CreateAnswerButton(DialogueAsset dialogueTree, string answerText, int nextDialogueSection)
    {
        var answerButton = new Button();
        answerButton.AddToClassList("AnswerText");
        answerButton.text = answerText;
        if (nextDialogueSection >= 0)
        {
            answerButton.clicked += () =>
            {
                StartDialogue(_currentDialogueTree, nextDialogueSection);
            };
        }
        else
        {
            answerButton.clicked += () =>
            {
                EndDialogue();
            };
        }

        return answerButton;
    }
}