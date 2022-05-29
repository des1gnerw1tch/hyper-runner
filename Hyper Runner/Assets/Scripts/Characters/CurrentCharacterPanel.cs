using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    /// <summary>
    /// Controls the section displaying the current character in the character panel.
    /// </summary>
    public class CurrentCharacterPanel : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Animator animator;
        [SerializeField] private TMP_Text characterNameText;
        [SerializeField] private TMP_Text characterFamilyText;

        private void Start()
        {
            UpdateInformation();
        }

        public void UpdateInformation()
        {
            CharacterSelect characterSelect = CharacterSelect.Instance;
            
            image.sprite = characterSelect.GetCurrentCharacterImage;
            animator.runtimeAnimatorController = characterSelect.GetCurrentCharacterShowcaseAnimatorController;
            characterNameText.text = characterSelect.GetCurrentCharacterName();
            characterFamilyText.text = characterSelect.GetCurrentCharacterFamily();
        }
    }
}
