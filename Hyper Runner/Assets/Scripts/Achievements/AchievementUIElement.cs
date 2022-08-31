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

        public virtual void UpdateContent()
        {
            
            if (achievement == null)
            {
                foreach (AchievementData a in AchievementManager.Instance.GetAchievementDataList())
                {
                    if (achievementID == a.ID)
                    {
                        achievement = a;
                    }
                }

                if (achievement == null)
                {
                    Debug.LogError("Could not find achievement in AchievementManager with ID: " + achievementID);
                }
            }
            
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
