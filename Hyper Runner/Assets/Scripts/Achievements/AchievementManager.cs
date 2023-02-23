using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Achievements
{
    /// <summary>
    /// Manages all the achievements added to the game
    /// </summary>
    public class AchievementManager : MonoBehaviour
    {
        [SerializeField] private List<AAchievement> achievements;

        public static AchievementManager Instance { get; private set; }

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

        public List<AchievementData> GetAchievementDataList()
        {
            List<AchievementData> l = new List<AchievementData>();
            
            foreach (AAchievement achievement in achievements)
            {
                l.Add(achievement.GetAchievementData());
            }

            return l;
        }

        // Initializes all of our achievements in our list to data given to us. 
        public void SetAchievementsFromData(List<AchievementData> data)
        {
            foreach (AchievementData d in data)
            {
                foreach (AAchievement a in achievements)
                {
                    if (d.ID == a.GetAchievementData().ID)
                    {
                        a.GetAchievementData().WriteData(d);
                    }
                }
            }
        }

        /**
         * An easy way to complete an achievement. This is not the only way of completing achievements. Many achievements of type AAchievement will
         * have their own listeners for criteria for an achievement, and will complete themselves. 
         */
        public void CompleteAchievementWithID(string achievementID)
        {
            AAchievement achievementToComplete = FindAchievementByID(achievementID);

            if (achievementToComplete == null)
            {
                Debug.LogError("Could not find achievement with ID: " + achievementID);
                return;
            }
            
            achievementToComplete.CompleteAchievement();
        }

        public void IncrementCountableAchievementWithID(string achievementID, int increment)
        {
            AAchievement achievementToComplete = FindAchievementByID(achievementID);

            if (achievementToComplete == null)
            {
                Debug.LogError("Could not find achievement with ID: " + achievementID);
                return;
            }

            if (achievementToComplete is ACountableAchievement)
            {
                ((ACountableAchievement)achievementToComplete).AddNumToProgress(increment);
            }
            else
            {
                Debug.LogError("Achievement with ID " + achievementID + " was not a countable achievement.");
            }
        }

        /**
         * Finds achievement by achievement ID. If cannot find achievement, return null. 
         */
        [CanBeNull]
        private AAchievement FindAchievementByID(string achievementID)
        {
            foreach (AAchievement a in achievements)
            {
                if (a.GetAchievementData().ID == achievementID)
                {
                    return a;
                }
            }

            return null;
        }
    }
}
