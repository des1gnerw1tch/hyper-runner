using System;
using UnityEngine;

namespace Characters
{
    public enum PlayableCharacterEnum
    {
        Tracy,
        John,
        Kevin,
        Jahmir
    }
    
    /// <summary>
    /// Holds all the data needed for a character in the game. 
    /// </summary>
    [Serializable]
    public class DanceCharacterData
    {
        [SerializeField] private PlayableCharacterEnum character;
        
        [SerializeField] private string name;
        
        // What "pack" of character is this in? A pack may be poketrainers, or rappers, etc. 
        [SerializeField] private string family;

        [SerializeField] private Sprite characterShowcaseSprite;

        [SerializeField] private RuntimeAnimatorController characterShowcaseController;
        
        // Prefab that will be spawned in game
        [SerializeField] private GameObject characterPrefab;

        // Sprite shown when character is unlocked in the game
        [SerializeField] private Sprite characterUnlockSprite;

        public PlayableCharacterEnum GetCharacterEnum()
        {
            return character;
        }

        public string GetName()
        {
            return name;
        }
        
        public string GetFamily()
        {
            return family;
        }

        public GameObject GetCharacterPrefab()
        {
            return characterPrefab;
        }

        // TODO: Rename this to something about the showcase sprite
        public Sprite GetSprite => characterShowcaseSprite;

        public RuntimeAnimatorController GetShowcaseController => characterShowcaseController;

        public Sprite GetUnlockSprite() => characterUnlockSprite;
    }
}
