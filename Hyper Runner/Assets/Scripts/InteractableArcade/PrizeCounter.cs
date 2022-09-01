using PrizeVendor;
using UnityEngine;

namespace InteractableArcade
{
    public class PrizeCounter : InteractableArcadeObjectUI
    {
        [SerializeField] private Dialogue robotDialogue;
        [SerializeField] private RobotAnimController robotAnimController;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            robotDialogue.StartDialogue();
            robotAnimController.TriggerWaveAnimation();
        }
    }
}
