using UnityEngine;

namespace Characters
{
    /// <summary>
    /// Spawns the character from CharacterSelect in an arcade scene
    /// </summary>
    public class SpawnPlayer : MonoBehaviour
    {
        [Header("TODO: Remove this field, for testing purposes only")]
        [SerializeField] private GameObject defaultCharacterForTesting;
        
        private void Awake()
        {
            #if UNITY_EDITOR
            
            if (FindObjectOfType<CharacterSelect>() == null)
            {
                Debug.LogWarning("Character select not found, spawning default character prefab");
                Instantiate(defaultCharacterForTesting);
                return;
            }
            
            #endif
            
            Instantiate(FindObjectOfType<CharacterSelect>().GetCharacterPrefab(), transform.position, Quaternion.identity);
        }
    }
}
