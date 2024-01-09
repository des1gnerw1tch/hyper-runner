using UnityEngine;
using UnityEngine.Events;
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

        /// Trigger close of all interactable arcade UI objects artificially, without user input
        public static readonly UnityEvent OnTriggerCloseEvent = new UnityEvent();

        private bool interactionsDisabled = false;
        [SerializeField] private string interactWhileDisabledSound = "spinNWinFail";
        
        private void Start() =>  playerInput = UIInputHandler.Instance.PlayerInputComponent;
        
        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            
            if (interactionsDisabled)
            {
                FindObjectOfType<AudioManager>().Play(interactWhileDisabledSound);
                return;
            }
            
            UIInputHandler.Instance.OnPause.AddListener(Close);
            UIInputHandler.Instance.OnBackButton.AddListener(Close);
            OnTriggerCloseEvent.AddListener(Close);
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

        public void DisableInteractions() => interactionsDisabled = true;
        public void EnableInteractions() => interactionsDisabled = false;
    }
}
