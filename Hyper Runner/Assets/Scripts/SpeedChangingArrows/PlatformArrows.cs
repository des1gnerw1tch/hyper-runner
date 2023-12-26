using UnityEngine;

namespace SpeedChangingArrows
{
    public class PlatformArrows : ASpeedChangingArrow
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                levelManager.SetPlayerMode("Platformer");
                this.UpdatePlayerSpeed();
            }
        }
    }
}
