using Characters;
using SaveFileSystem;
using UnityEngine;

namespace InteractableArcade
{
    public class ClawMachine : InteractableArcadeObjectUI
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterUnlock characterUnlock;
        [SerializeField] private int cost;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            int remainingTokens = GameDataManager.Instance.AddTokens(-cost);
            if (remainingTokens == -1)
            {
                // Reject attempt to use machine if do not have sufficient funds. 
                FindObjectOfType<AudioManager>().Play("characterLocked");
                this.Close();
                return;
            }
            
            animator.SetTrigger("Activate");

            PlayableCharacterEnum? characterToUnlock = GameDataManager.Instance.GetRandomLockedCharacter();
            if (!characterToUnlock.HasValue)
            {
                // TODO: Display feedback that all characters are unlocked
                GameDataManager.Instance.AddTokens(cost);
                this.Close();
                return;
            }

            characterUnlock.UnlockCharacterWithAnimation(characterToUnlock.Value);
        }
    }
}
