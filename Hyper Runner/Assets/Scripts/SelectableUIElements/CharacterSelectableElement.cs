using UnityEngine;
using Characters;

namespace SelectableUIElements
{
    /// <summary>
    /// A selectable element that changes the current player character.
    /// </summary>
    public class CharacterSelectableElement : ASelectableElement
    {
        [SerializeField] private PlayableCharacterEnum character;
        [SerializeField] private GameObject selectedBorder;
        
        public override void Selected()
        {
            CharacterSelect.Instance.ChangeCurrentCharacter(character);
        }

        public override void Highlight()
        {
            selectedBorder.SetActive(true);
        }

        public override void StopHighlight()
        {
            selectedBorder.SetActive(false);
        }
    }
}
