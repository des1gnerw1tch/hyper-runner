using System.Collections;
using BossFight.Cyber;
using UnityEngine;
using UnityEngine.Animations;

public class RacingBossFightCameraController : MonoBehaviour
{
    [SerializeField] private ParentConstraint parentConstraint;
    
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Transform cameraTargetForBossFigure;
    [SerializeField] private Transform cameraTargetForPlayerCar;
    [SerializeField] private BossCarAI bossCarAI;

    [SerializeField] private float secondsUntilStartTransitionToPlayerCam;

    [SerializeField] private float durationTransitionFromBossCarToPlayerCar;
    [SerializeField] private float animStepInSecondsForTransitionFromBossCarToPlayerCar;

    [SerializeField] private GameObject cinematicCamera;
    [SerializeField] private GameObject playerCamera;
    private bool transitioningToPlayer = false;
    
    private void Start()
    {
        StartCoroutine(IStartTransitionToPlayerCam());
    }
    
    private void Update()
    {
        if (transitioningToPlayer)
        {
            cameraPivot.LookAt(cameraTargetForPlayerCar);
        }
        else
        {
            cameraPivot.LookAt(cameraTargetForBossFigure);
        }
    }

    private IEnumerator IStartTransitionToPlayerCam()
    {
        yield return new WaitForSeconds(secondsUntilStartTransitionToPlayerCam);
        StartTransitionToPlayerCam();
    }

    private void StartTransitionToPlayerCam()
    {
        transitioningToPlayer = true;
        ConstraintSource source = new ConstraintSource();
        StartCoroutine(BlendParentConstraintWeight(source));
    }

    private IEnumerator BlendParentConstraintWeight(ConstraintSource source)
    {
        float timeElapsed = 0f;
        while (timeElapsed < durationTransitionFromBossCarToPlayerCar)
        {
            UpdateParentConstraintWeight(Mathf.Min(timeElapsed / durationTransitionFromBossCarToPlayerCar, 1.0f));
            yield return new WaitForSeconds(animStepInSecondsForTransitionFromBossCarToPlayerCar);
            timeElapsed += animStepInSecondsForTransitionFromBossCarToPlayerCar;
        }
        EndBeginningCutscene();
       
    }

    private void EndBeginningCutscene()
    {
        bossCarAI.SetIsInBeginningCutscene(false);
        cinematicCamera.SetActive(false);
        playerCamera.SetActive(true);
    }

    private void UpdateParentConstraintWeight(float completionFraction)
    {
        ChangeParentConstraintSourceWeight(0, Mathf.Clamp(1 - completionFraction, 0, 1));
        ChangeParentConstraintSourceWeight(1, completionFraction);
        
    }
    
    private void ChangeParentConstraintSourceWeight(int sourceIndex, float newWeight)
    {
        ConstraintSource tempSource = parentConstraint.GetSource(sourceIndex);
        tempSource.weight = newWeight;
        parentConstraint.SetSource(sourceIndex, tempSource);
    }
}
