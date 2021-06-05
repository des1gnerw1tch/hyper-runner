using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalParryObject : AParryObject
{
    public override void onParry()  {
      Debug.Log("This is a normal parry object");
    }
}
