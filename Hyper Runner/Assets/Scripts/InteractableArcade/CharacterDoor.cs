using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractableArcade
{
    public class CharacterDoor : AInteractableArcadeObject
    {
        [SerializeField] private GameObject characterPanel;
        [SerializeField] private PlayerInput playerInput;

        private void Start()
        {
            UIInputHandler.Instance.OnPause.AddListener(ClosePanel);
            UIInputHandler.Instance.OnBackButton.AddListener(ClosePanel);
        }

        private void ClosePanel()
        {
            if (characterPanel.activeSelf)
            {
                characterPanel.SetActive(false);
                playerInput.SwitchCurrentActionMap("3D");
            }

        }

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            characterPanel.SetActive(true);
            playerInput.SwitchCurrentActionMap("UI");
        }
    }
}
