using UnityEngine;
using UnityEngine.Animations;

public class RacingBossFightCameraController : MonoBehaviour
{
    [SerializeField] private ParentConstraint parentConstraint;
    
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Transform cameraTargetForBossFigure;

    void Update()
    {
        cameraPivot.LookAt(cameraTargetForBossFigure);
    }
}
