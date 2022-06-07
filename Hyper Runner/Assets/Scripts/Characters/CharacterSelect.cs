using ScriptableObjects;
using UnityEngine;

namespace Characters
{
    /// <summary>
    /// Stores your current character, along with it's data.
    /// </summary>
    public class CharacterSelect : MonoBehaviour
    {
        
        [SerializeField] private CharacterContainer characters;
        
        private GameObject currentCharacter;
        private DanceCharacterData characterData;
        
        public static CharacterSelect Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);
            }
            
            //TODO: Remove this and have character save on file.
            ChangeCurrentCharacter(PlayableCharacterEnum.Tracy);
        }

        public GameObject GetCharacterPrefab() => currentCharacter;

        public void ChangeCurrentCharacter(PlayableCharacterEnum characterEnum)
        {
            GameObject character = characters.GetCharacterPrefabByEnum(characterEnum);
            
            if (character == null)
            {
                Debug.LogError("Could not change character because character == null");
                return;
            }

            currentCharacter = character;

            characterData = characters.GetCharacterDataByEnum(characterEnum);
        }

        public string GetCurrentCharacterName()
        {
            return characterData.GetName();
        }

        public string GetCurrentCharacterFamily()
        {
            return characterData.GetFamily();
        }

        public Sprite GetCurrentCharacterImage => characterData.GetSprite;

        public RuntimeAnimatorController GetCurrentCharacterShowcaseAnimatorController => characterData.GetShowcaseController;
    }
}
