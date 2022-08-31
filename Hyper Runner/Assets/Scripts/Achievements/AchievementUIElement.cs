using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Achievements
{
    public class AchievementUIElement : MonoBehaviour
    {
        [SerializeField] private string achievementID;
        [SerializeField] private TextMeshProUGUI tokenRewardText;
        [SerializeField] private Image border;

        protected AchievementData achievement;
        
        private void Start()
        {
            foreach (AchievementData a in AchievementManager.Instance.GetAchievementDataList())
            {
                if (achievementID == a.ID)
                {
                    achievement = a;
                }
            }
            
            UpdateContent();
        }

        public virtual void UpdateContent()
        {
            tokenRewardText.text = achievement.tokensToEarn + "";
            
            if (achievement.completed)
            {
                ShowAchievementCompleted();
            }
        }
        
        private void ShowAchievementCompleted()
        {
            //TODO: Make this a checkmark or something more aesthetically pleasing...
            
            border.color = Color.green;
        }
    }
}
