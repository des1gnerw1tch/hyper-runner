using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractableArcade
{
    /// <summary>
    /// The SpinNWin machine in the arcade! :)
    /// </summary>
    public class SpinNWin : InteractableArcadeObjectUI
    {
        [SerializeField] private Transform spinner;
        private Coroutine rotateRoutine;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
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
