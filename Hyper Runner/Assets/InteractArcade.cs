using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// deals with player interacting with elements in arcade scene
public class InteractArcade : MonoBehaviour {

    [SerializeField] private IInteractableArcadeObject currentInteractableObject;

    // When player presses interact key
    void OnInteract() {
        if (this.currentInteractableObject != null) {
            this.currentInteractableObject.Interact(this);
        }
    }

    public void SetCurrentInteractable(IInteractableArcadeObject obj) {
        this.currentInteractableObject = obj;
    }

    public void ClearCurrentInteractable() {
        this.currentInteractableObject = null;
    }
}
