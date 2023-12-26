using UnityEngine;

namespace SpeedChangingArrows
{
    /// <summary>
    /// Arrows that change the running/flying speed of the player
    /// </summary>
    public class SpeedChangeArrows : ASpeedChangingArrow
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                this.UpdatePlayerSpeed();
            }
        }
    }
}
