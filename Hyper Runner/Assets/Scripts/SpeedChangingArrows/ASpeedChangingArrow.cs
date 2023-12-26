using UnityEngine;
using UnityEngine.Serialization;

namespace SpeedChangingArrows
{
    public abstract class ASpeedChangingArrow : MonoBehaviour
    {
        [FormerlySerializedAs("playerRunningSpeed")]
        [SerializeField] private float playerFloatingSpeed;
        
        [SerializeField] private float surroundingSpeedMultiplier;
        [SerializeField] private InterpolateTrigger interpolationTrigger;
    
        [Header("Auto-get components")]
        [SerializeField] protected ALevelManager levelManager;
        
        
        private void Start() => levelManager = ALevelManager.Instance;

        protected void UpdatePlayerSpeed()
        {
            levelManager.playerCamMoveSpeed = playerFloatingSpeed;
            Parallax.multiplier = surroundingSpeedMultiplier;
            levelManager.UpdateSpeeds();

            if (interpolationTrigger != null) {
                this.interpolationTrigger.StartInterpolateObjects();
            } else {
                Debug.LogError("No Object to interpolate selected");
            }
        }
    }
}
