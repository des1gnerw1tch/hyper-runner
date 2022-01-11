using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A pause button, from the menu when you pause from playing a rhythm game, not from menu 3D scene
/// </summary>
public abstract class AInGamePauseButton : MonoBehaviour, IPauseMenuButton
{
    [SerializeField] protected UIManager uiManager;
    
    public abstract void OnClick();
}
