using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace PrizeVendor
{
    /// <summary>
    /// Controls the Prize vendors animations. 
    /// </summary>
    public class RobotAnimController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Animator animator;
        [SerializeField] private MultiAimConstraint headAimConstraint;

        [SerializeField] private float distanceToStartLookAtPlayer;
        [SerializeField] private float distanceToFullyLookAtPlayer;

        public void TriggerWaveAnimation() => animator.SetTrigger("Wave");

        private void Update()
        {
            float distance = Vector3.Distance(transform.position, player.position);
            
            if (distance < distanceToFullyLookAtPlayer)
            {
                headAimConstraint.weight = 1;
            } else if (distance < distanceToStartLookAtPlayer)
            {
                headAimConstraint.weight = 1 - (Math.Abs(distance - distanceToFullyLookAtPlayer) / Math.Abs(distanceToStartLookAtPlayer - distanceToFullyLookAtPlayer));
            }
            else
            {
                headAimConstraint.weight = 0;
            }
        }
    }
}
