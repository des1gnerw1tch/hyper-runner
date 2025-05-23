using SaveFileSystem;
using UnityEngine;

namespace Achievements
{
    /// <summary>
    /// Base class for all achievements to be made in the game. Achievements should have data, and also should have some type of listener to
    /// update the achievement data when progress is made. 
    /// </summary>
    public abstract class AAchievement : MonoBehaviour
    {
        [SerializeField] protected AchievementData achievement;

        public AchievementData GetAchievementData() => achievement;

        public void CompleteAchievement()
        {
            if (achievement.completed)
            {
                return;
            }
            
            achievement.completed = true;
            GameDataManager.Instance.SaveAchievementData();
        }
    }
}
