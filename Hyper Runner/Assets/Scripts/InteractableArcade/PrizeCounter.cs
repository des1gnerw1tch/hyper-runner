using PrizeVendor;
using UnityEngine;

namespace InteractableArcade
{
    public class PrizeCounter : AInteractableArcadeObjectUI
    {
        [SerializeField] private GameObject dialogueBoxGameObject;
        [SerializeField] private Dialogue robotDialogue;
        [SerializeField] private RobotAnimController robotAnimController;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            ShowDialogueWindow();
            robotAnimController.TriggerWaveAnimation();
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
