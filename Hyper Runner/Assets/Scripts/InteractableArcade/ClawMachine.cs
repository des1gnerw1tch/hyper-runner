using Characters;
using UnityEngine;

namespace InteractableArcade
{
    public class ClawMachine : InteractableArcadeObjectUI
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterUnlock characterUnlock;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            animator.SetTrigger("Activate");
            characterUnlock.UnlockCharacterWithAnimation(PlayableCharacterEnum.John);
        }
    }
}
