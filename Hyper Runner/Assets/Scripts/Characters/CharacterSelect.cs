using System.ComponentModel.Design.Serialization;
using ScriptableObjects;
using UnityEngine;

namespace Characters
{
    public class CharacterSelect : MonoBehaviour
    {
        [SerializeField] private GameObject currentCharacter;
        [SerializeField] private CharacterContainer characters;
        
        public static CharacterSelect Instance { get; private set; }
        
        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        public GameObject GetCharacterPrefab() => currentCharacter;

        public void ChangeCurrentCharacter(PlayableCharacterEnum characterEnum)
        {
            GameObject character = characters.GetCharacterDataByEnum(characterEnum);
            
            if (character == null)
            {
                Debug.LogError("Could not change character because character == null");
                return;
            }

            currentCharacter = character;
        }
    }
}
