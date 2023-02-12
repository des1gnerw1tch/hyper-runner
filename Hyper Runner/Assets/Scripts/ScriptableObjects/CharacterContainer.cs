using UnityEngine;
using Characters;

namespace ScriptableObjects
{
    /// <summary>
    /// Holds all of the Dance Characters data in the game! Links all of the related assets to one character together.
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
    public class CharacterContainer : ScriptableObject
    {
        [SerializeField] private DanceCharacterData[] characters;
        
        public GameObject GetCharacterPrefabByEnum(PlayableCharacterEnum playableCharacter)
        {
            foreach (DanceCharacterData character in characters)
            {
                if (playableCharacter == character.GetCharacterEnum())
                {
                    return character.GetCharacterPrefab();
                }
            }
            
            Debug.LogError("Could not find name in Character Container scriptable object");
            return null;
        }

        public DanceCharacterData GetCharacterDataByEnum(PlayableCharacterEnum playableCharacter)
        {
            foreach (DanceCharacterData character in characters)
            {
                if (playableCharacter == character.GetCharacterEnum())
                {
                    return character;
                }
            }
            
            Debug.LogError("Could not find name in Character Container scriptable object");
            return null;
        }
    }
}
