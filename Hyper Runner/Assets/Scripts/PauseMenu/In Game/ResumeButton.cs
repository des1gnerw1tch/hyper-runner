using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ResumeButton : AInGamePauseButton
{
    public override void OnClick()
    {
        uiManager.ResumeGame();
    }
}
