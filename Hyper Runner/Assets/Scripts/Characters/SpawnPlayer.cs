using UnityEngine;

namespace Characters
{
    /// <summary>
    /// Spawns the character from CharacterSelect in an arcade scene
    /// </summary>
    public class SpawnPlayer : MonoBehaviour
    {
        private void Awake()
        {
            Instantiate(FindObjectOfType<CharacterSelect>().GetCharacterPrefab(), transform.position, Quaternion.identity);
        }
    }
}
