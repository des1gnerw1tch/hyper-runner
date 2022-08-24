using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private string[] textToDisplay;

    [SerializeField] private float delayBetweenEachCharacter;

    private AudioManager audioManager;

    private int interactCount = 0;
    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    public void StartDialogue()
    {
        tmp.text = "";
        StartCoroutine(DisplayNextCharacter(0, textToDisplay[interactCount]));
        interactCount++;
        if (interactCount == textToDisplay.Length)
        {
            interactCount = 0;
        }
    }

    private IEnumerator DisplayNextCharacter(int curChar, string _textToDisplay)
    {
        if (curChar > _textToDisplay.Length)
        {
            DialogueEnded();
            yield break;
        }
        
        if (curChar != 0 && !Char.IsWhiteSpace(_textToDisplay, curChar - 1))
        {
            yield return new WaitForSeconds(delayBetweenEachCharacter);
            PlayRandomRobotSound();
        }

        tmp.text = _textToDisplay.Substring(0, curChar);
        StartCoroutine(DisplayNextCharacter(curChar + 1, _textToDisplay));
    }

    private void DialogueEnded()
    {
        Debug.Log("Dialogue Ended");
    }

    private void PlayRandomRobotSound()
    {
        int rand = Random.Range(1, 5);
        audioManager.Play("robotBleep" + rand);
    }
    
}
