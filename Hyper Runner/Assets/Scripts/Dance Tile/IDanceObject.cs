using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDanceObject {
    void OnUpDanceKeyPress();
    void OnUpDanceKeyRelease();
    void OnDownDanceKeyPress();
    void OnDownDanceKeyRelease();
    void OnLeftDanceKeyPress();
    void OnLeftDanceKeyRelease();
    void OnRightDanceKeyPress();
    void OnRightDanceKeyRelease();
    void OnAnyDanceKeyPress();

    // When a key is pressed while this dance object is active
    void KeyPressed(string key);

    // When key is released while this dance object is active
    void Released(string key);
}
