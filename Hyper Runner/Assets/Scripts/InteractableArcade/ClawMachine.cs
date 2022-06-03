using UnityEngine;

namespace InteractableArcade
{
    public class ClawMachine : AInteractableArcadeObject
    {
        [SerializeField] private Animator animator;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            animator.SetTrigger("Activate");
        }
    }
}
