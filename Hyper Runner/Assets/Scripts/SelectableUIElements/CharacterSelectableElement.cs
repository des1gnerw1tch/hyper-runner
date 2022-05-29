using UnityEngine;
using Characters;
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
        
        // To change current character sprite and animator.
        [SerializeField] private CurrentCharacterPanel currentCharacterPanel;

        public override void Selected()
        {
            base.Selected();
            
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
