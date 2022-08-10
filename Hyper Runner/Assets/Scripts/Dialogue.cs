using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private string textToDisplay;

    [SerializeField] private float delayBetweenEachCharacter;
    
    public void StartDialogue()
    {
        tmp.text = "";
        StartCoroutine(DisplayNextCharacter(0));
    }

    private IEnumerator DisplayNextCharacter(int curChar)
    {
        if (curChar > textToDisplay.Length)
        {
            DialogueEnded();
            yield break;
        }
        
        if (curChar != 0 && !Char.IsWhiteSpace(textToDisplay, curChar - 1))
        {
            yield return new WaitForSeconds(delayBetweenEachCharacter);
        }

        tmp.text = textToDisplay.Substring(0, curChar);
        StartCoroutine(DisplayNextCharacter(curChar + 1));
    }

    private void DialogueEnded()
    {
        Debug.Log("Dialogue Ended");
    }
    
}
