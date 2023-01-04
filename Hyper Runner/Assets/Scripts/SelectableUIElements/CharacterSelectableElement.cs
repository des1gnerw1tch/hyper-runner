using UnityEngine;
using Characters;
using SaveFileSystem;
using UnityEngine.UI;

namespace SelectableUIElements
{
    /// <summary>
    /// A selectable element that changes the current player character.
    /// </summary>
    public class CharacterSelectableElement : ASelectableElement
    {
        [SerializeField] private PlayableCharacterEnum character;
        [SerializeField] private GameObject selectedBorder;
        private const string CHARACTER_SELECTED_BUT_NOT_UNLOCKED_SOUND = "characterLocked";
        
        // To change current character sprite and animator.
        [SerializeField] private CurrentCharacterPanel currentCharacterPanel;
        

        public override void Selected()
        {
            if (!GameDataManager.Instance.IsCharacterUnlocked(character))
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
    }
}
