using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelManager
{
    // updates the values of speed for both the camera and the player
    void UpdateSpeeds();

    // using either "Rhythm" or "Platformer" as mode, performs operations
    // to switch mode of game
    void SetPlayerMode(string mode);


}
