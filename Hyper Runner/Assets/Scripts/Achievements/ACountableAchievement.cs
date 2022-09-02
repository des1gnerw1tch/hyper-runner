using SaveFileSystem;
using UnityEngine;

namespace Achievements
{
    public abstract class ACountableAchievement : AAchievement
    {
        public void AddNumToProgress(int num)
        {
            achievement.currentProgress = Mathf.Clamp(achievement.currentProgress + num, 0, achievement.numToReach);
            
            if (achievement.currentProgress == achievement.numToReach)
            {
                CompleteAchievement();
            }
            else
            {
                // Consider removing this: how often should we save achievement data to file? Maybe only after return to arcade scene?
                GameDataManager.Instance.SaveAchievementData();
            }
        }
    }
}
