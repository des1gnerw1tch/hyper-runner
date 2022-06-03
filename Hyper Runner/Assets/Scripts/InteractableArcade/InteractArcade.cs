using UnityEngine;

namespace InteractableArcade
{
// deals with player interacting with elements in arcade scene
    public class InteractArcade : MonoBehaviour
    {

        [SerializeField] private AInteractableArcadeObject currentInteractableObject;

        // When player presses interact key
        void OnInteract()
        {
            if (this.currentInteractableObject != null)
            {
                this.currentInteractableObject.Interact(this);
            }
        }

        public void SetCurrentInteractable(AInteractableArcadeObject obj)
        {
            this.currentInteractableObject = obj;
        }

        public void ClearCurrentInteractable()
        {
            this.currentInteractableObject = null;
        }
    }
}
