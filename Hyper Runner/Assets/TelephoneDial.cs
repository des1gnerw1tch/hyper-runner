using System.Collections.Generic;
using UnityEngine;

public class TelephoneDial : MonoBehaviour
{
    [SerializeField] private List<int> currentNumberDialed;
    [SerializeField] private List<int> correctNumber;
    [SerializeField] private string wrongNumberSound;
    [SerializeField] private string correctNumberSound;
    
    private void OnEnable() => currentNumberDialed.Clear();

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
                FindObjectOfType<AudioManager>().Play(correctNumberSound);
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
        Debug.Log("You just typed the correct number!");
    }
}
