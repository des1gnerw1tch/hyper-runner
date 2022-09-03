using System;
using UnityEngine;

namespace Achievements
{
    
    /// <summary>
    /// Holds data for an achievement. 
    /// </summary>
    [Serializable]
    public class AchievementData
    {
        public string ID;
        public bool completed;
        public int tokensToEarn;
        public bool rewardCollected;
        
        [Header("For countable achievements")]
        public int currentProgress;
        public int numToReach;
        
        public void WriteData(AchievementData data)
        {
            ID = data.ID;
            completed = data.completed;
            tokensToEarn = data.tokensToEarn;
            rewardCollected = data.rewardCollected;
            currentProgress = data.currentProgress;
            numToReach = data.numToReach;
        }

        public bool IsRewardCollectable() => completed && !rewardCollected;
    }
}
