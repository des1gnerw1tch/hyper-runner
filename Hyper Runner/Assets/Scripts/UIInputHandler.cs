using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// handles player input for UI elements, such as pausing. Should live on same gameobject as PlayerInput
// Passes many inputs to our UI Manager
public class UIInputHandler : MonoBehaviour
{
    public PlayerInput PlayerInputComponent { get; private set; }

    // UI Events
    public UnityEvent OnScrollUp { get; } = new UnityEvent();
    
    public UnityEvent OnScrollDown { get; } = new UnityEvent();
    
    public UnityEvent OnScrollLeft { get; } = new UnityEvent();
    
    public UnityEvent OnScrollRight { get; } = new UnityEvent();
    
    public UnityEvent OnSelectOption { get; } = new UnityEvent();
    
    public UnityEvent OnPause { get; } = new UnityEvent();

    public UnityEvent OnBackButton { get; } = new UnityEvent();

    public static UIInputHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        PlayerInputComponent = GetComponent<PlayerInput>();
    }

    // When Player pushes a "Pause Game" button
    void OnPauseGame() {
        OnPause.Invoke();
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

    void OnBack()
    {
        OnBackButton.Invoke();
    }
}
