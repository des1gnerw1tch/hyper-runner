using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableArcadeObject {
    void Interact(InteractArcade player); // Player interacts with this arcade object
}
