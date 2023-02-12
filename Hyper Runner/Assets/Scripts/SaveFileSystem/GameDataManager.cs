using Achievements;
using Characters;
using UnityEngine;
using UnityEngine.Events;

namespace SaveFileSystem
{
    /// <summary>
    /// Stores current data. Loads and saves current PlayerSaveData from file. Has functions that change the data state of the game, such as giving
    /// tokens to the player, or unlocking a new character. 
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
                currentSaveData = new PlayerSaveData(achievementManager);
                SaveGame();
            }
            else // save file found
            {
                achievementManager.SetAchievementsFromData(currentSaveData.GetAchievementData());
                currentSaveData.AddNewCharacters(); // Adds new characters if new characters were added since last update
                SaveGame();
                
                //TODO: Remove
                Debug.Log("Current level high scores");
                foreach (string level in currentSaveData.GetLevelDataTable().Keys)
                {
                    Debug.Log(level + " "  + currentSaveData.GetLevelDataTable()[level].highScore);
                }
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
            SaveGame();
        }
            
        /// <summary>
        /// Updates the save file to any achievement changes under AchievementManager
        /// </summary>
        public void SaveAchievementData()
        {
            currentSaveData.SetAchievementData(achievementManager.GetAchievementDataList());
            SaveGame();
        }

        // Sets a character to be locked or unlocked, and then saves the game. 
        public void SetCharacterUnlocked(PlayableCharacterEnum character, bool isUnlocked)
        {
            currentSaveData.SetCharacterUnlocked(character, isUnlocked);
            SaveGame();
        }

        public bool IsCharacterUnlocked(PlayableCharacterEnum character) => currentSaveData.IsCharacterUnlocked(character);

        // Gets current character player is using. 
        public PlayableCharacterEnum GetCurrentCharacter() => currentSaveData.GetCurrentCharacter();

        // Gets current character player is using. 
        public void SetCurrentCharacter(PlayableCharacterEnum currentCharacter)
        {
            currentSaveData.SetCurrentCharacter(currentCharacter);
            SaveGame();
        } 
        
        private void SaveGame()  => FileSaveManager.SavePlayer(currentSaveData);

        
        // Set high score of level if this grade is the highest. If level not found, add level to Dictionary.
        public bool ShouldSetLevelHighScore(string levelSceneName, LevelGrade grade)
        {
            bool wasHighScoreSet = currentSaveData.ShouldSetLevelHighScore(levelSceneName, grade);
            SaveGame();
            return wasHighScoreSet;
        }
    }
}