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
        
        [Header("For countable achievements")]
        public int currentProgress;
        public int numToReach;
        

        public void WriteData(AchievementData data)
        {
            ID = data.ID;
            completed = data.completed;
            currentProgress = data.currentProgress;
            numToReach = data.numToReach;
            tokensToEarn = data.tokensToEarn;
        }
    }
}
