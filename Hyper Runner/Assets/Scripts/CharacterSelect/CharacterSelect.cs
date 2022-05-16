using ScriptableObjects;
using UnityEngine;

namespace Characters
{
    public class CharacterSelect : MonoBehaviour
    {
        [SerializeField] private GameObject currentCharacter;
        
        [SerializeField] private CharacterContainer characters;
    }
}
