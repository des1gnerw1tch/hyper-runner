using UnityEngine;

namespace Parry_System
{
    public class clockParryObject : AParryObject
    {
        [SerializeField] private float musicPitch = 1f;
        [SerializeField] private float effectLength = 1f;
        [SerializeField] private MusicSync musicSync;

        public override void OnParry()
        {
            base.OnParry();
            musicSync.changePitch(musicPitch, effectLength);
        }
    }
}
