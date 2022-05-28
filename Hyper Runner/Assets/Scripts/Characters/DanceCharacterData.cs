using System;
using UnityEngine;
using UnityEngine.Playables;

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
        
        // What "pack" of character is this in? A pack may be poketrainers, or rappers, etc. 
        [SerializeField] private string family;
        
        // Prefab that will be spawned in game
        [SerializeField] private GameObject characterPrefab;

        public PlayableCharacterEnum GetCharacterEnum()
        {
            return character;
        }

        public string GetPackName()
        {
            return family;
        }

        public GameObject GetCharacterPrefab()
        {
            return characterPrefab;
        }
    }
}
