using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractableArcade
{
    public class PrizeCounter : AInteractableArcadeObjectUI
    {
        [SerializeField] private GameObject dialogueBoxGameObject;
        [SerializeField] private Dialogue robotDialogue;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            ShowDialogueWindow();
        }

        private void ShowDialogueWindow()
        {
            dialogueBoxGameObject.SetActive(true);
            robotDialogue.StartDialogue();
        }

        protected override void Close()
        {
            base.Close();
            dialogueBoxGameObject.SetActive(false);
        }
    }
}
