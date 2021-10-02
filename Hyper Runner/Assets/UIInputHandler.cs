using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles player input for UI elements, such as pausing.
// Passes many inputs to our UI Manager
public class UIInputHandler : MonoBehaviour {
    [SerializeField] private UIManager uiManager;

    // When Player pushes a "Pause Game" button
    void OnPauseGame() {
        this.uiManager.PauseKeyPressed(); // delegates tasks to uiManager
    }
}
