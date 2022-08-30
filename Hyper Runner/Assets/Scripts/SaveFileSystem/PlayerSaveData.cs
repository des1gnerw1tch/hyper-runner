using System.Collections.Generic;
using Achievements;

namespace SaveFileSystem
{
    /// <summary>
    /// Data for a player. To be loaded in and saved. 
    /// </summary>
    [System.Serializable]
    public class PlayerSaveData
    {
        private int playTokens;

        private List<AchievementData> achievementData;

        #region Constructors
        
        public PlayerSaveData() {}

        #endregion

        public void SetPlayTokens(int tokens) => playTokens = tokens;
        
        public int GetNumTokens() => playTokens;

        public void SetAchievementData(List<AchievementData> data) => achievementData = data;

        public List<AchievementData> GetAchievementData() => achievementData;
    }
}
