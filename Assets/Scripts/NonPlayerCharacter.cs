using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    [SerializeField] private string m_DialogText = "...";
    
    public void DisplayDialogue()
    {
        UIHandler.instance.DisplayDialogue(m_DialogText);
    }
}