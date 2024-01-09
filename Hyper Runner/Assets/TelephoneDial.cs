using System.Collections;
using System.Collections.Generic;
using InteractableArcade;
using UnityEngine;

public class TelephoneDial : MonoBehaviour
{
    [SerializeField] private List<int> currentNumberDialed;
    [SerializeField] private List<int> correctNumber;
    [SerializeField] private string wrongNumberSound;
    [SerializeField] private string correctNumberSound;
    [SerializeField] private float timeToWaitBetweenRingAndRecording;
    [SerializeField] private string firstRecordingSound;
    [SerializeField] private string radioMusicSound;
    [SerializeField] private float volumeOfRadioMusicWhileTalkingOnPhone;
    [SerializeField] private InteractableArcadeObjectUI phoneTableInteractable;
    
    public void ClearPhoneNumber() => currentNumberDialed.Clear();

    /// <summary>
    /// A button press of one number. 
    /// </summary>
    public void PressNumber(int num)
    {
        currentNumberDialed.Add(num);
        if (currentNumberDialed.Count >= correctNumber.Count)
        {
            bool correct = CheckCorrectNumber();
            currentNumberDialed.Clear();
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
