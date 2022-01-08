using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockParryObject : AParryObject
{
    [SerializeField] private float musicPitch = 1f;
    [SerializeField] private float effectLength = 1f;
    [SerializeField] private MusicSync musicSync;

    public override void OnParry()  {
      musicSync.changePitch(musicPitch, effectLength);
    }
}
