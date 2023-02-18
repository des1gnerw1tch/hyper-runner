using System;
using System.Collections.Generic;
using Achievements;
using Characters;
using UnityEngine;
using Random = UnityEngine.Random;

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

        private Dictionary<PlayableCharacterEnum, bool> charactersUnlockedStatus;

        private PlayableCharacterEnum currentCharacter;

        private Dictionary<string, LevelData> levelDataTable;

        #region Constructors

        public PlayerSaveData(AchievementManager achievementManager)
        {
            SetAchievementData(achievementManager.GetAchievementDataList());

            // All characters start locked. Start Tracy as current character
            charactersUnlockedStatus = new Dictionary<PlayableCharacterEnum, bool>();
            currentCharacter = PlayableCharacterEnum.Tracy;
            
            AddNewCharacters();
            levelDataTable = new Dictionary<string, LevelData>();
        }

        #endregion

        public void SetPlayTokens(int tokens) => playTokens = tokens;
        
        public int GetNumTokens() => playTokens;

        public void SetAchievementData(List<AchievementData> data) => achievementData = data;

        public List<AchievementData> GetAchievementData() => achievementData;

        // Sets a character to be locked or unlocked. 
        public void SetCharacterUnlocked(PlayableCharacterEnum character, bool isUnlocked)
        {
            if (!charactersUnlockedStatus.ContainsKey(character))
            {
                Debug.LogError("Character cannot be found in characters unlocked status dictionary. Make sure that when we add a new character, it " +
                               "gets automatically added to this dictionary.");
                return;
            }
            
            charactersUnlockedStatus[character] = isUnlocked;
        }

        public bool IsCharacterUnlocked(PlayableCharacterEnum character)
        {
            if (!charactersUnlockedStatus.ContainsKey(character))
            {
                Debug.LogError("Character cannot be found in characters unlocked status dictionary. Make sure that when we add a new character, it " +
                               "gets automatically added to this dictionary.");
                return false;
            }

            return charactersUnlockedStatus[character];
        }

        // Adds characters that are not currently in dictionary to dictionary. Characters default will start locked, unless character is Tracy. Tracy is
        // unlocked from the start. 
        public void AddNewCharacters()
        {
            foreach (PlayableCharacterEnum character in Enum.GetValues(typeof(PlayableCharacterEnum)))
            {
                if (!charactersUnlockedStatus.ContainsKey(character))
                {
                    charactersUnlockedStatus.Add(character, character == PlayableCharacterEnum.Tracy);
                }
            }
        }

        // Gets current character player is using. 
        public PlayableCharacterEnum GetCurrentCharacter() => currentCharacter;

        // Gets current character player is using. 
        public void SetCurrentCharacter(PlayableCharacterEnum currentCharacter) => this.currentCharacter = currentCharacter;

        // Gets a random locked character from the roster. No rarity system yet, but this would be cool.
        // Returns null if all characters unlocked
        public PlayableCharacterEnum? GetRandomLockedCharacter()
        {
            List<PlayableCharacterEnum> lockedCharacters = new List<PlayableCharacterEnum>();
            foreach (PlayableCharacterEnum character in charactersUnlockedStatus.Keys)
            {
                if (charactersUnlockedStatus[character] == false)
                {
                    lockedCharacters.Add(character);
                }
            }

            if (lockedCharacters.Count == 0)
            {
                return null;
            }

            int num = Random.Range(0, lockedCharacters.Count);
            return lockedCharacters[num];
        }
        
        // Set high score of level if this grade is the highest. If level not found, add level to Dictionary.
        public bool ShouldSetLevelHighScore(string levelSceneName, LevelGrade grade)
        {
            if (levelDataTable.ContainsKey(levelSceneName))
            {
                if (grade >= levelDataTable[levelSceneName].highScore)
                {
                    return false;
                }
                // High score reached
                levelDataTable[levelSceneName].highScore = grade;
                return true;
            }
            else
            {
                levelDataTable.Add(levelSceneName, new LevelData());
                levelDataTable[levelSceneName].highScore = grade;
                return true;
            }
        }
        
        public Dictionary<string, LevelData> GetLevelDataTable() => new Dictionary<string, LevelData>(levelDataTable);

    }
}
