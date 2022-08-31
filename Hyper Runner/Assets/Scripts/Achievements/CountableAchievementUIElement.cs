using TMPro;
using UnityEngine;

namespace Achievements
{
    public class CountableAchievementUIElement : AchievementUIElement
    {
        [SerializeField] private TextMeshProUGUI progressFractionText;

        public override void UpdateContent()
        {
            base.UpdateContent();
            progressFractionText.text = achievement.currentProgress + "/" + achievement.numToReach;
            UpdateSliderValue();
        }

        private void UpdateSliderValue()
        {
            Debug.Log("Slider updating not implemented yet");
            //throw new NotImplementedException();
        }
    }
}
