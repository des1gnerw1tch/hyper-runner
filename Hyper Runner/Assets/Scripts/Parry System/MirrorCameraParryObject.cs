using UnityEngine;

namespace Parry_System
{
    public class MirrorCameraParryObject : ExplodingParryObject
    {
        // Start is called before the first frame update
        [Header("Mirror Camera Object Required Components (Auto)")] [SerializeField]
        private CameraOrientation[] cameraOrientations;

        [SerializeField] private FlashPanel flashPanel;

        [Header("Mirror Camera Object Required Serialization")] [SerializeField]
        private Color colorToFlash;

        // on first frame call
        public override void Start()
        {
            base.Start();
            this.cameraOrientations = FindObjectsOfType<CameraOrientation>();
            this.flashPanel = FindObjectOfType<FlashPanel>();
        }

        // when parry object is parried off of
        public override void OnParry()
        {
            foreach (var o in cameraOrientations)
            {
                o.Mirror();
            }
            this.flashPanel.Flash(this.colorToFlash);
            base.OnParry();
        }
    }
}