using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using ArcadeCamera;
using SaveFileSystem;
using ScriptableObjects;
using TMPro;
using UnityEngine.InputSystem;

namespace InteractableArcade
{
    /// <summary>
    /// The SpinNWin machine in the arcade! :)
    /// </summary>
    public class SpinNWin : AInteractableArcadeObject
    {
        [SerializeField] private GameObject uiContent;
        private PlayerInput playerInput;
        private bool isInteracting = false;
        
        [SerializeField] private Transform spinner;
        [SerializeField] private Transform raycastEmitter;

        [SerializeField] private Transform cameraViewingPos;
        [SerializeField] private float camLerpTime;

        [SerializeField] private SpinNWinMaterialToReward materialToRewardCollection;

        [SerializeField] private TextMeshProUGUI wagerText;
        private int wager = 0;

        private bool spinnerSpinning = false;

        public void Start() => playerInput = UIInputHandler.Instance.PlayerInputComponent;
        
        public override void Interact(InteractArcade player)
        {
            if (!isInteracting)
            {
                base.Interact(player);
                playerInput.SwitchCurrentActionMap("UI");
                uiContent.SetActive(true);
                wager = 0;
                UpdateWagerText();
                UIInputHandler.Instance.OnScrollUp.AddListener(IncWager);
                UIInputHandler.Instance.OnScrollDown.AddListener(DecWager);
                UIInputHandler.Instance.OnSelectOption.AddListener(StartSpinner);
                UIInputHandler.Instance.OnPause.AddListener(Close);
                UIInputHandler.Instance.OnBackButton.AddListener(Close);
                isInteracting = true;
            }
            else
            {
               Close();
            }
        }

        private void IncWager()
        {
            int tokensAvailable = GameDataManager.Instance.GetNumTokens();
            Debug.Log("Tried to inc wager, tokens available: " + tokensAvailable);
            if (wager < tokensAvailable)
            {
                wager++;
                Debug.Log("Wager: " + wager);
                UpdateWagerText();
                FindObjectOfType<AudioManager>().Play("scroll");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("characterLocked");
            }
        }

        private void DecWager()
        {
            if (wager > 0)
            {
                wager--;
                UpdateWagerText();
                FindObjectOfType<AudioManager>().Play("scroll");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("characterLocked");
            }
        }

        private void UpdateWagerText()
        {
            wagerText.text = wager + "";
        }

        private void StartSpinner()
        {
            if (wager == 0)
            {
                return;
            }
            
            GameDataManager.Instance.AddTokens(-wager);
            spinnerSpinning = true;
            UIInputHandler.Instance.OnScrollUp.RemoveListener(IncWager);
            UIInputHandler.Instance.OnScrollDown.RemoveListener(DecWager);
            UIInputHandler.Instance.OnSelectOption.RemoveListener(StartSpinner);
            FindObjectOfType<AudioManager>().Play("spinNWinStart");
            
            LerpCameraPosition.Instance.ToggleLerp(cameraViewingPos, camLerpTime);
            float spinSpeed = Random.Range(1000, 2000);
            StartCoroutine(RotateSpinner(spinSpeed));
        }

        private IEnumerator RotateSpinner(float spinSpeed)
        {
            while (spinSpeed > 0)
            {
                spinSpeed = Mathf.Clamp(spinSpeed - 5, 0, Single.PositiveInfinity);
                spinner.Rotate(0, spinSpeed * Time.deltaTime, 0, Space.Self);
                yield return new WaitForEndOfFrame();
            }

            int? multiplier = GetRewardMultiplierWithRaycast();
            
            if (multiplier.HasValue)
            {
                if (multiplier > 0)
                {
                    FindObjectOfType<AudioManager>().Play("tracyYay");
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("spinNWinFail");
                }
                GameDataManager.Instance.AddTokens(wager * multiplier.Value);
            }
            else
            {
                Debug.LogError("Reward should not be null.");
            }

            spinnerSpinning = false;
            Close();
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
        
        // Returns player to regular position, deactivates UI objects and remove UI listeners
        private void Close()
        {
            if (spinnerSpinning)
            {
                return;
            }
            
            uiContent.SetActive(false);
            LerpCameraPosition.Instance.TryLerpOriginalPosition();
            UIInputHandler.Instance.OnScrollUp.RemoveListener(IncWager);
            UIInputHandler.Instance.OnScrollDown.RemoveListener(DecWager);
            UIInputHandler.Instance.OnSelectOption.RemoveListener(StartSpinner);
            UIInputHandler.Instance.OnPause.RemoveListener(Close);
            UIInputHandler.Instance.OnBackButton.RemoveListener(Close);
            playerInput.SwitchCurrentActionMap("3D");
            isInteracting = false;
        }
    }
}
