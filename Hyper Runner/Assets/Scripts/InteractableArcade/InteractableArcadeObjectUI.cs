using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractableArcade
{
    /// <summary>
    /// A interactable arcade object where a window pops up. Input map is switched to UI mode. Input map is switched back to 3D mode when
    /// interaction is closed. 
    /// </summary>
    public class InteractableArcadeObjectUI : AInteractableArcadeObject
    {
        [SerializeField] private GameObject uiContent;
        
        private PlayerInput playerInput;

        private bool isInteracting = false;
        
        private void Start() =>  playerInput = UIInputHandler.Instance.PlayerInputComponent;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            UIInputHandler.Instance.OnPause.AddListener(Close);
            UIInputHandler.Instance.OnBackButton.AddListener(Close);
            playerInput.SwitchCurrentActionMap("UI");
            isInteracting = true;
            uiContent.SetActive(true);
        } 
        
        // Player disengages with this arcade object
        protected void Close()
        {
            if (isInteracting)
            {
                playerInput.SwitchCurrentActionMap("3D");
                isInteracting = false;
                uiContent.SetActive(false);
                UIInputHandler.Instance.OnPause.RemoveListener(Close);
                UIInputHandler.Instance.OnBackButton.RemoveListener(Close);
            }
        }
    }
}
