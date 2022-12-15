using System.Collections;
using System.Collections.Generic;
using InteractableArcade;
using UnityEngine;

/**
 * A chair that you can sit in. Starts an animation where it puts your camera in the chair!
 */
public class SittableChair : AInteractableArcadeObject
{
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private FirstPersonCameraController cameraController;
    [SerializeField] private FirstPersonMovement playerMovement;
    [SerializeField] private Transform sitPos;
    [SerializeField] private float lerpTime = 3;
    
    private bool isInteracting = false;
    
    private Vector3 originalCamLoc;
    private Quaternion originalCamRot;

    public override void Interact(InteractArcade player)
    {
        base.Interact(player);
        
        if (isInteracting)
        {
            StartCoroutine(LerpOutOfChair());
            return;
        }
        cameraController.Lock();
        playerMovement.Lock();
        
        originalCamLoc = cameraHolder.position;
        originalCamRot = cameraHolder.rotation;
        
        isInteracting = true;
        StartCoroutine(LerpToChair());
    }

    private IEnumerator LerpToChair()
    {
        float timer = 0;
        float progress = 0;
        
        while (progress <= 1)
        {
            progress = timer / lerpTime;
            cameraHolder.position = Vector3.Lerp(originalCamLoc, sitPos.position, progress);
            cameraHolder.rotation = Quaternion.Lerp(originalCamRot, sitPos.rotation, progress);
            timer += Time.deltaTime;
            Debug.Log(progress);
            yield return new WaitForEndOfFrame();
        }
        FindObjectOfType<AudioManager>().Play("sitInChair");
    }

    private IEnumerator LerpOutOfChair()
    {
        float timer = 0;
        float progress = 0;
        
        while (progress <= 1)
        {
            progress = timer / lerpTime;
            cameraHolder.position = Vector3.Lerp(sitPos.position, originalCamLoc, progress);
            cameraHolder.rotation = Quaternion.Lerp(sitPos.rotation, originalCamRot, progress);
            timer += Time.deltaTime;
            Debug.Log(progress);
            yield return new WaitForEndOfFrame();
        }
        cameraController.Unlock();
        playerMovement.Unlock();
        isInteracting = false;
    }
}
