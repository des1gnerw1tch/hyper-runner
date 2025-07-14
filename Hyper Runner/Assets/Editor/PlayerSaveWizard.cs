using Characters;
using SaveFileSystem;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    // Offers basic operations (like delete current save file) when the program is not running
    public class PlayerSaveWizard : EditorWindow
    {
        private PlayableCharacterEnum characterToUnlock;
        private LevelGrade gradeToSet;
        private bool bossFightCompletedToSet;
        private int tokensToAdd;
        
        [MenuItem("Custom/Player Save Wizard")]
        public static void ShowWindow() => GetWindow<PlayerSaveWizard>("Player Save Wizard");

        private PlayerSaveData playerData;

        [SerializeField] private RhythmLevelsContainer levels;

        // Code for the window
        private void OnGUI()
        {
            if (GUILayout.Button("Delete current save"))
            {
                FileSaveManager.DeletePlayer();
                Debug.Log("Deleted current save successfully.");
            }
            
            characterToUnlock = (PlayableCharacterEnum) EditorGUILayout.EnumPopup("Player to unlock", characterToUnlock);
            if (GUILayout.Button("Unlock Character"))
            {
                playerData = FileSaveManager.LoadPlayer();
                if (playerData == null)
                {
                    Debug.LogError("No save file found to modify. Start the game once and try again.");
                }
                else
                {
                    playerData.SetCharacterUnlocked(characterToUnlock, true);
                    FileSaveManager.SavePlayer(playerData);
                    Debug.Log("Successfully unlocked character.");
                }
            }

            tokensToAdd = EditorGUILayout.IntField("Number of tokens to give", tokensToAdd);
            if (GUILayout.Button("Give Tokens"))
            {
                playerData = FileSaveManager.LoadPlayer();
                if (playerData == null)
                {
                    Debug.LogError("No save file found to modify. Start the game once and try again.");
                }
                else
                {
                    playerData.SetPlayTokens(playerData.GetNumTokens() + tokensToAdd);
                    FileSaveManager.SavePlayer(playerData);
                    Debug.Log("Successfully added " + tokensToAdd + " tokens to save. Total tokens= " + playerData.GetNumTokens());
                }
            }

            gradeToSet = (LevelGrade) EditorGUILayout.EnumPopup("Grade to set levels to", gradeToSet);
            bossFightCompletedToSet = EditorGUILayout.Toggle("Complete all boss fights", bossFightCompletedToSet);
            if (GUILayout.Button("Set all levels/bossfights to selected"))
            {
                playerData = FileSaveManager.LoadPlayer();
                if (playerData == null)
                {
                    Debug.LogError("No save file found to modify. Start the game once and try again.");
                }
                else
                {
                    foreach (string lvl in levels.GetAllRhythmLevelScenes())
                    {
                        playerData.ForceSetLevelHighScore(lvl, gradeToSet);
                        playerData.SetLevelsBossFightCompleted(lvl, bossFightCompletedToSet);
                        Debug.Log("Successfully set high score for " + lvl + " to " + gradeToSet);
                        Debug.Log("Successfully set boss fight for " + lvl + " to " + (bossFightCompletedToSet? "completed" : "uncompleted"));
                    }
                    FileSaveManager.SavePlayer(playerData);
                }
            }
        }
    }
}