using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADanceObject : MonoBehaviour, IDanceObject
{
  // method stubs to override, all player input
  public virtual void OnUpDanceKeyPress()  {

  }

  public virtual void OnDownDanceKeyPress()  {

  }

  public virtual void OnUpDanceKeyRelease() {

  }

  public virtual void OnDownDanceKeyRelease() {

  }

  public virtual void OnAnyDanceKeyPress()  {

  }
}
