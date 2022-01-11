using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// handles player input for UI elements, such as pausing.
// Passes many inputs to our UI Manager
public class UIInputHandler : MonoBehaviour {
    [Header("Required Prefab in Scene, automatically fetched")]
    [SerializeField] private UIManager uiManager;

    //private UnityEvent onScrollUp;

    // UI Scroll Events
    public UnityEvent OnScrollUp { get; } = new UnityEvent();
    public UnityEvent OnScrollDown { get; } = new UnityEvent();
    public UnityEvent OnScrollLeft { get; } = new UnityEvent();
    public UnityEvent OnScrollRight { get; } = new UnityEvent();
    public UnityEvent OnSelectOption { get; } = new UnityEvent();


    
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    
    // When Player pushes a "Pause Game" button
    void OnPauseGame() {
        this.uiManager.PauseKeyPressed(); // delegates tasks to uiManager
    }
    
    /// <summary>
    /// Calls events for scroll in UI
    /// </summary>
    void OnUp() // when up key is pressed for UI
    {
        OnScrollUp.Invoke();
    }

    void OnDown()
    {
        OnScrollDown.Invoke();
    }

    void OnLeft()
    {
        OnScrollLeft.Invoke();
    }

    void OnRight()
    {
        OnScrollRight.Invoke();
    }

    void OnSelect()
    {
        OnSelectOption.Invoke();
    }
}
