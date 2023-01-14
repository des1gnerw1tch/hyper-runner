using Characters;
using SaveFileSystem;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    // Offers basic operations (like delete current save file) when the program is not running
    public class PlayerSaveWizard : EditorWindow
    {
        private PlayableCharacterEnum characterToUnlock;
        
        [MenuItem("Custom/Player Save Wizard")]
        public static void ShowWindow() => GetWindow<PlayerSaveWizard>("Player Save Wizard");

        private PlayerSaveData playerData;

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
        }
    }
}