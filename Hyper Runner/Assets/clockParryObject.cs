using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockParryObject : AParryObject
{
    public override void onParry()  {
      Debug.Log("Clock object");
    }
}
