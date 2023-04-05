using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using ArcadeCamera;

namespace InteractableArcade
{
    /// <summary>
    /// The SpinNWin machine in the arcade! :)
    /// </summary>
    public class SpinNWin : AInteractableArcadeObject
    {
        [SerializeField] private Transform spinner;
        private Coroutine rotateRoutine;

        [SerializeField] private Transform cameraViewingPos;
        [SerializeField] private float camLerpTime;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            LerpCameraPosition.Instance.ToggleLerp(cameraViewingPos, camLerpTime);
            
            if (rotateRoutine != null)
            {
                return;
            }
            
            float spinSpeed = Random.Range(2000, 4000);
            rotateRoutine = StartCoroutine(RotateSpinner(spinSpeed));
        }

        private IEnumerator RotateSpinner(float spinSpeed)
        {
            while (spinSpeed > 0)
            {
                spinSpeed = Mathf.Clamp(spinSpeed - 5, 0, Single.PositiveInfinity);
                spinner.Rotate(0, spinSpeed * Time.deltaTime, 0, Space.Self);
                yield return new WaitForEndOfFrame();
            }

            rotateRoutine = null;
        }
    }
}
