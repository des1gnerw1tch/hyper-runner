using System.Collections.Generic;
using UnityEngine;

namespace Achievements
{
    /// <summary>
    /// Manages all the achievements added to the game
    /// </summary>
    public class AchievementManager : MonoBehaviour
    {
        [SerializeField] private List<AAchievement> achievements;

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
    }
}
