using System.Collections;
using SaveFileSystem;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    // Manages unlocking characters and showing the UI popup for it. 
    public class CharacterUnlock : MonoBehaviour
    {
        [SerializeField] private CharacterContainer characterContainer;

        [SerializeField] private GameObject content;
        [SerializeField] private Image characterImage;
        [SerializeField] private TextMeshProUGUI characterFamilyText;
        [SerializeField] private TextMeshProUGUI characterNameText;

        // Not technically an animation for now, but this will unlock a character and show a panel showing what character was unlocked.
        public void UnlockCharacterWithAnimation(PlayableCharacterEnum character)
        {
            GameDataManager save = GameDataManager.Instance;
            if (save.IsCharacterUnlocked(character))
            {
                Debug.LogError("Tried to unlock character that is already unlocked");
                return;
            }
            
            save.SetCharacterUnlocked(character, true);
            
            DanceCharacterData data = characterContainer.GetCharacterDataByEnum(character);
            characterImage.sprite = data.GetUnlockSprite();
            characterFamilyText.text = data.GetFamily();
            characterNameText.text = data.GetName();
            content.SetActive(true);
            StartCoroutine(DeactivateContent());
        }
        
        // TODO: This should be an input to exit this screen.
        private IEnumerator DeactivateContent()
        {
            FindObjectOfType<AudioManager>().Play("rewardCollected");
            for (int i = 0; i < 6; i++)
            {
                content.SetActive(false);
                yield return new WaitForSeconds(.1f);
                content.SetActive(true);
                yield return new WaitForSeconds(.1f);
            }
            
            FindObjectOfType<AudioManager>().Play("tracyYay");
        }


    }
}
