using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using ArcadeCamera;
using SaveFileSystem;
using ScriptableObjects;

namespace InteractableArcade
{
    /// <summary>
    /// The SpinNWin machine in the arcade! :)
    /// </summary>
    public class SpinNWin : AInteractableArcadeObject
    {
        [SerializeField] private Transform spinner;
        [SerializeField] private Transform raycastEmitter;
        
        private Coroutine rotateRoutine;

        [SerializeField] private Transform cameraViewingPos;
        [SerializeField] private float camLerpTime;

        [SerializeField] private SpinNWinMaterialToReward materialToRewardCollection;

        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            LerpCameraPosition.Instance.ToggleLerp(cameraViewingPos, camLerpTime);
            
            if (rotateRoutine != null)
            {
                return;
            }
            
            float spinSpeed = Random.Range(1000, 2000);
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

            int? reward = GetRewardMultiplierWithRaycast();
            
            if (reward.HasValue)
            {
                GameDataManager.Instance.AddTokens(reward.Value);
            }
            else
            {
                Debug.LogError("Reward should not be null.");
            }
            
            rotateRoutine = null;
            
        }

        private int? GetRewardMultiplierWithRaycast()
        {
            RaycastHit hit;
            Debug.DrawRay(raycastEmitter.position, raycastEmitter.forward, Color.cyan, 20000);
            if (Physics.Raycast(raycastEmitter.position, raycastEmitter.forward, out hit))
            {
                Material hitMaterial = hit.transform.gameObject.GetComponent<Renderer>().material;
                return materialToRewardCollection.GetMultiplierFromMaterial(hitMaterial);
            }

            return null;
        }
    }
}
