using System.Collections.Generic;
using UnityEngine;

namespace Achievements
{
    /// <summary>
    /// Updates achievement UI elements
    /// </summary>
    public class AchievementsUIHelper : MonoBehaviour
    {
        private AchievementUIElement[] achievementUIElements;

        public static AchievementsUIHelper Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        
        private void Start()
        {
            achievementUIElements = FindObjectsOfType<AchievementUIElement>(true);
        }
        
        public void UpdateContent()
        {
            List<AchievementUIElement> rewardsToCollect = new List<AchievementUIElement>();
            
            foreach (AchievementUIElement element in achievementUIElements)
            {
                element.UpdateContent();
                
                if (element.IsRewardCollectable())
                {
                    rewardsToCollect.Add(element);
                }
            }
            
            foreach (AchievementUIElement element in rewardsToCollect)
            {
                element.PlayAchievementCompletedAnim();
                element.RedeemReward();
            }

            if (rewardsToCollect.Count > 0)
            {
                FindObjectOfType<AudioManager>().Play("rewardCollected");
            }
            
        }
    }
}
