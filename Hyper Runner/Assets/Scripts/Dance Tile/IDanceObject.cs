using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDanceObject
{
  void OnUpDanceKeyPress();
  void OnUpDanceKeyRelease();
  void OnDownDanceKeyPress();
  void OnDownDanceKeyRelease();
  void OnAnyDanceKeyPress();
}
