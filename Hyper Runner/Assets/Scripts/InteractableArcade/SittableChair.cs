using UnityEngine;
using ArcadeCamera;

namespace InteractableArcade
{
    /**
    * A chair that you can sit in. Starts an animation where it puts your camera in the chair!
    */
    public class SittableChair : AInteractableArcadeObject
    {
        [SerializeField] private Transform sittingCameraPosition;
        [SerializeField] private float lerpTime = 3;

        private bool isInteracting = false;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            LerpCameraPosition.Instance.ToggleLerp(sittingCameraPosition, lerpTime);
        }
    }
}
