using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : AInGamePauseButton
{
    
    public override void OnClick()
    {
        uiManager.ExitGame();
    }
}
