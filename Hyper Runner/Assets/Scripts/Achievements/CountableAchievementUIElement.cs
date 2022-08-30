using TMPro;
using UnityEngine;

namespace Achievements
{
    public class CountableAchievementUIElement : AchievementUIElement
    {
        [SerializeField] private TextMeshProUGUI progressFractionText;
        [SerializeField] private int currentNumber;
        [SerializeField] private int numberToReach;
        
        public void UpdateCountableProgress(int numToAdd)
        {
            currentNumber = Mathf.Clamp(currentNumber + numToAdd, 0, numberToReach);
            UpdateCountableProgress();
        }
        
        public void UpdateCountableProgress()
        {
            progressFractionText.text = currentNumber + "/" + numberToReach;
            UpdateSliderValue();
        }

        public void UpdateSliderValue()
        {
            Debug.Log("Slider updating not implemented yet");
            //throw new NotImplementedException();
        }
    }
}
