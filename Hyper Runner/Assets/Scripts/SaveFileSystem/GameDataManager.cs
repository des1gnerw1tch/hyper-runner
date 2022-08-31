using Achievements;
using UnityEngine;
using UnityEngine.Events;

namespace SaveFileSystem
{
    /// <summary>
    /// Loads and saves PlayerSaveData to file. 
    /// </summary>
    public class GameDataManager : MonoBehaviour
    {
        private PlayerSaveData currentSaveData;

        [SerializeField] private AchievementManager achievementManager;
        
        public UnityEvent PlayerBalanceChanged { get; } = new UnityEvent();
        
        public static GameDataManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            Instance = this;
            
            currentSaveData = FileSaveManager.LoadPlayer();
            
            if (currentSaveData == null)
            {
                Debug.Log("Save file not found. Creating new save.");
                currentSaveData = new PlayerSaveData();
                currentSaveData.SetAchievementData(achievementManager.GetAchievementDataList());
                FileSaveManager.SavePlayer(currentSaveData);
            }
            else
            {
                achievementManager.SetAchievementsFromData(currentSaveData.GetAchievementData());
            }
        }
        
        public int AddTokens(int num)
        {
            int newValue = GetNumTokens() + num;
            
            if (newValue < 0)
            {
                Debug.LogError("Insufficient funds");
                return -1;
            }

            if (GetNumTokens() != newValue)
            {
                SetNewTokenBalance(newValue);
                PlayerBalanceChanged.Invoke();
            }
            
            return GetNumTokens();
        }
        
        public int GetNumTokens() => currentSaveData.GetNumTokens();
        
        private void SetNewTokenBalance(int numTokens)
        {
            currentSaveData.SetPlayTokens(numTokens);
            FileSaveManager.SavePlayer(currentSaveData);
        }
            
        /// <summary>
        /// Updates the save file to any achievement changes under AchievementManager
        /// </summary>
        public void SaveAchievementData()
        {
            currentSaveData.SetAchievementData(achievementManager.GetAchievementDataList());
            FileSaveManager.SavePlayer(currentSaveData);
        }
    }
}