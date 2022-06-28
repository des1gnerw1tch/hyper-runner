using UnityEngine;

namespace SaveFileSystem
{
    /// <summary>
    /// Data for a player. To be loaded in and saved. 
    /// </summary>
    [System.Serializable]
    public class PlayerSaveData
    {
        private int playTokens;

        #region Constructors
        
        public PlayerSaveData() {}

        public PlayerSaveData(PlayerSaveData data)
        {
            playTokens = data.playTokens;
        }
        
        #endregion

        public void AddPlayToken() => playTokens++;

        public int GetPlayTokens() => playTokens;
    }
}
