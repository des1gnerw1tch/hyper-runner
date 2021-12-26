using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles player input for UI elements, such as pausing.
// Passes many inputs to our UI Manager
public class UIInputHandler : MonoBehaviour {
    [Header("Required Prefab in Scene, automatically fetched")]
    [SerializeField] private UIManager uiManager;

    // When Player pushes a "Pause Game" button
    private void Start() {
        uiManager = FindObjectOfType<UIManager>();
    }
    void OnPauseGame() {
        this.uiManager.PauseKeyPressed(); // delegates tasks to uiManager
    }
}
