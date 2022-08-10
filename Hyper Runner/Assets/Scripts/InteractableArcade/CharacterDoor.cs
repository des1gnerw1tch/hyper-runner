using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractableArcade
{
    public class CharacterDoor : AInteractableArcadeObjectUI
    {
        [SerializeField] private GameObject characterPanel;

        protected override void Close()
        {
            base.Close();
            
            if (characterPanel.activeSelf)
            {
                characterPanel.SetActive(false);
            }

        }

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            characterPanel.SetActive(true);
        }
    }
}
