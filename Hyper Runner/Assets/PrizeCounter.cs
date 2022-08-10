using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractableArcade
{
    public class PrizeCounter : AInteractableArcadeObject
    {
        [SerializeField] private GameObject dialogueBoxGameObject;
        [SerializeField] private Dialogue robotDialogue;

        [SerializeField] private PlayerInput playerInput;
        
        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            ShowDialogueWindow();
        }

        private void ShowDialogueWindow()
        {
            playerInput.SwitchCurrentActionMap("UI");
            dialogueBoxGameObject.SetActive(true);
            robotDialogue.StartDialogue();
        }

        protected override void Close()
        {
            dialogueBoxGameObject.SetActive(false);
            playerInput.SwitchCurrentActionMap("3D");
        }
    }
}
