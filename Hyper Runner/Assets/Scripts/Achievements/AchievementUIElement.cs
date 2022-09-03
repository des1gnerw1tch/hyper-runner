using System.Collections;
using SaveFileSystem;
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
        
        public bool IsRewardCollectable() => achievement.IsRewardCollectable();

        public void PlayAchievementCompletedAnim()
        {
            StartCoroutine(Anim());
            
            IEnumerator Anim()
            {
                for (int i = 0; i < 14; i++)
                {
                    if (i % 2 == 0)
                    {
                        border.color = Color.white;
                    }
                    else
                    {
                        border.color = Color.green;
                    }

                    yield return new WaitForSeconds(.2f);
                }
            }
        }

        // Where the player gets the reward tokens.
        public void RedeemReward()
        {
            GameDataManager.Instance.AddTokens(achievement.tokensToEarn);
            achievement.rewardCollected = true;
            GameDataManager.Instance.SaveAchievementData();
        }
        
    }
}
