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
        [SerializeField] private PlayerInput playerInput;
        
        private void Start()
        {
            UIInputHandler.Instance.OnPause.AddListener(Close);
            UIInputHandler.Instance.OnBackButton.AddListener(Close);
        }

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            playerInput.SwitchCurrentActionMap("UI");
        } 
        
        // Player disengages with this arcade object
        protected virtual void Close()
        {
            playerInput.SwitchCurrentActionMap("3D");
        }
        
    }
}
