using UnityEngine;
using Characters;
using SaveFileSystem;

namespace SelectableUIElements
{
    /// <summary>
    /// A selectable element that changes the current player character.
    /// </summary>
    public class CharacterSelectableElement : ASelectableElement
    {
        [SerializeField] private PlayableCharacterEnum character;
        [SerializeField] private GameObject lockedCharacterDisplay;
        [SerializeField] private GameObject unlockedCharacterDisplay;
        
        [SerializeField] private GameObject selectedBorder;
        private const string CHARACTER_SELECTED_BUT_NOT_UNLOCKED_SOUND = "characterLocked";
        
        // To change current character sprite and animator.
        [SerializeField] private CurrentCharacterPanel currentCharacterPanel;

        private void OnEnable()
        {
            if (IsCharacterLocked())
            {
                lockedCharacterDisplay.SetActive(true);
                unlockedCharacterDisplay.SetActive(false);
            }
            else
            {
                lockedCharacterDisplay.SetActive(false);
                unlockedCharacterDisplay.SetActive(true);
            }
        }
        
        public override void Selected()
        {
            if (IsCharacterLocked())
            {
                FindObjectOfType<AudioManager>().Play(CHARACTER_SELECTED_BUT_NOT_UNLOCKED_SOUND);
                return;
            }

            FindObjectOfType<AudioManager>().Play(selectedSound);
            CharacterSelect.Instance.ChangeCurrentCharacter(character);
            currentCharacterPanel.UpdateInformation();
        }

        public override void Highlight()
        {
            base.Highlight();
            
            selectedBorder.SetActive(true);
        }

        public override void StopHighlight()
        {
            selectedBorder.SetActive(false);
        }

        private bool IsCharacterLocked() => !GameDataManager.Instance.IsCharacterUnlocked(character);
    }
}
