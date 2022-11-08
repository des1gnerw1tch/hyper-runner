using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Achievements
{
    public class CountableAchievementUIElement : AchievementUIElement
    {
        [SerializeField] private TextMeshProUGUI progressFractionText;
        [SerializeField] private Slider slider;

        public override void UpdateContent()
        {
            base.UpdateContent();
            progressFractionText.text = achievement.currentProgress + "/" + achievement.numToReach;
            UpdateSliderValue();
        }

        private void UpdateSliderValue() => slider.value = (float) achievement.currentProgress / achievement.numToReach;
    }
}
