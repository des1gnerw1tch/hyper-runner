using UnityEngine;
using Characters;

namespace SelectableUIElements
{
    /// <summary>
    /// A selectable element that changes the current player character.
    /// </summary>
    public class CharacterSelectableElement : ASelectableElement
    {
        [SerializeField] private string characterName;
        [SerializeField] private GameObject selectedBorder;
        
        public override void Selected()
        {
            CharacterSelect.Instance.ChangeCurrentCharacter(characterName);
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
