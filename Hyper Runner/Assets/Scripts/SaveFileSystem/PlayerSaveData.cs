using System;
using System.Collections.Generic;
using Achievements;
using Characters;
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

        private List<AchievementData> achievementData;

        private Dictionary<PlayableCharacterEnum, bool> charactersUnlockedStatus;

        #region Constructors

        public PlayerSaveData(AchievementManager achievementManager)
        {
            SetAchievementData(achievementManager.GetAchievementDataList());

            // All characters start locked.
            charactersUnlockedStatus = new Dictionary<PlayableCharacterEnum, bool>();
            AddNewCharacters();
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
    }
}
