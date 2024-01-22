using System.Collections;
using System.Collections.Generic;
using Achievements;
using InteractableArcade;
using TMPro;
using UnityEngine;

public class TelephoneDial : MonoBehaviour
{
    [SerializeField] private List<int> currentNumberDialed;
    [SerializeField] private TextMeshProUGUI currentNumber;
    [SerializeField] private List<int> correctNumber;
    [SerializeField] private string wrongNumberSound;
    [SerializeField] private string correctNumberSound;
    [SerializeField] private float timeToWaitBetweenRingAndRecording;
    [SerializeField] private string firstRecordingSound;
    [SerializeField] private string radioMusicSound;
    [SerializeField] private float volumeOfRadioMusicWhileTalkingOnPhone;
    [SerializeField] private InteractableArcadeObjectUI phoneTableInteractable;

    private bool clearingNumberFromUI = false;
    
    /// <summary>
    /// A button press of one number. 
    /// </summary>
    public void PressNumber(int num)
    {
        if (clearingNumberFromUI)
        {
            return;
        }
        
        if (currentNumber.text.Length == 3 || currentNumber.text.Length == 7)
        {
            currentNumber.text += "-";
        }
        currentNumber.text += num;
        
        currentNumberDialed.Add(num);
        if (currentNumberDialed.Count >= correctNumber.Count)
        {
            bool correct = CheckCorrectNumber();
            currentNumberDialed.Clear();
            StartCoroutine(ClearNumberFromUIDelayed());
            if (correct)
            {
                StartEasterEgg();
            }
            else
            {
                FindObjectOfType<AudioManager>().Play(wrongNumberSound);
            }
        }
    }

    public void ClearPhoneNumber()
    {
        currentNumberDialed.Clear();
        currentNumber.text = "";
    } 

    private IEnumerator ClearNumberFromUIDelayed()
    {
        clearingNumberFromUI = true;
        yield return new WaitForSeconds(1f);
        currentNumber.text = "";
        clearingNumberFromUI = false;
    }

    private bool CheckCorrectNumber()
    {
        for (int i = 0; i < correctNumber.Count; i++)
        {
            if (correctNumber[i] != currentNumberDialed[i])
            {
                return false;
            }
        }
        return true;
    }

    private void StartEasterEgg()
    {
        FindObjectOfType<AchievementManager>().CompleteAchievementWithID("firstCallShrunk");
        FindObjectOfType<AudioManager>().Play(correctNumberSound);
        // Close telephone UI panel and don't allow interaction with telephone until cutscene is over
        InteractableArcadeObjectUI.OnTriggerCloseEvent.Invoke();
        phoneTableInteractable.DisableInteractions();
        
        StartCoroutine(FirstVoiceRecording());
    }

    // Play first voice recording, dampening volume of radio music while playing. 
    private IEnumerator FirstVoiceRecording()
    {
        yield return new WaitForSeconds(timeToWaitBetweenRingAndRecording);
        AudioManager a = FindObjectOfType<AudioManager>();
        a.Play(firstRecordingSound);
        float recordingLength = a.GetAudioClipLength(firstRecordingSound);
        float previousVol = a.ChangeVolume(radioMusicSound, volumeOfRadioMusicWhileTalkingOnPhone);
        yield return new WaitForSeconds(recordingLength);
        a.ChangeVolume(radioMusicSound, previousVol);
        phoneTableInteractable.EnableInteractions();
    }
}
