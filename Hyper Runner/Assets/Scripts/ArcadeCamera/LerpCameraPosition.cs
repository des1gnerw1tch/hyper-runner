using System.Collections;
using UnityEngine;

namespace ArcadeCamera
{
    /// <summary>
    /// Can lerp position of the camera to another location. This will disable first person movement and the
    /// player camera controller. 
    /// </summary>
    public class LerpCameraPosition : MonoBehaviour
    {
        [SerializeField] private FirstPersonCameraController cameraController;
        [SerializeField] private FirstPersonMovement playerMovement;
        private float lerpTime;

        private Transform dest;

        private bool isFocused = false;
        private bool isLerping = false;

        private Vector3 originalCamLoc;
        private Quaternion originalCamRot;

        public static LerpCameraPosition Instance { get; private set; }

        public void Start()
        {
            if (Instance != null && Instance != this)
            {
                GameObject.Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public void LerpToDest(Transform dest, float lerpTime)
        {
            if (isFocused || isLerping)
            {
                return;
            }

            this.dest = dest;
            this.lerpTime = lerpTime;
            isFocused = true;

            cameraController.Lock();
            playerMovement.Lock();

            Transform t = transform;
            originalCamLoc = t.position;
            originalCamRot = t.rotation;

            StartCoroutine(_LerpToDest());
        }

        private IEnumerator _LerpToDest()
        {
            isLerping = true;
            float timer = 0;
            float progress = 0;

            while (progress <= 1)
            {
                progress = timer / lerpTime;
                transform.position = Vector3.Lerp(originalCamLoc, dest.position, progress);
                transform.rotation = Quaternion.Lerp(originalCamRot, dest.rotation, progress);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            isLerping = false;
        }

        public void LerpToOriginalPos()
        {
            if (!isLerping && isFocused)
            {
                StartCoroutine(_LerpToOriginalPos());
            }
        }

        private IEnumerator _LerpToOriginalPos()
        {
            isLerping = true;
            float timer = 0;
            float progress = 0;

            while (progress <= 1)
            {
                progress = timer / lerpTime;
                transform.position = Vector3.Lerp(dest.position, originalCamLoc, progress);
                transform.rotation = Quaternion.Lerp(dest.rotation, originalCamRot, progress);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            cameraController.Unlock();
            playerMovement.Unlock();
            isFocused = false;
            isLerping = false;
        }
    }
}