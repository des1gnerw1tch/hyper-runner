using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractableArcade
{
    /// <summary>
    /// A interactable arcade object where a window pops up. Input map is switched to UI mode. Input map is switched back to 3D mode when
    /// interaction is closed. 
    /// </summary>
    public abstract class AInteractableArcadeObjectUI : AInteractableArcadeObject
    {
        private PlayerInput playerInput;

        private bool isInteracting = false;
        private void Start()
        {
            UIInputHandler.Instance.OnPause.AddListener(Close);
            UIInputHandler.Instance.OnBackButton.AddListener(Close);
            playerInput = UIInputHandler.Instance.PlayerInputComponent;
        }

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            playerInput.SwitchCurrentActionMap("UI");
            isInteracting = true;
        } 
        
        // Player disengages with this arcade object
        protected virtual void Close()
        {
            if (isInteracting)
            {
                playerInput.SwitchCurrentActionMap("3D");
                isInteracting = false;
            }
        }
        
    }
}
