using UnityEngine;

namespace SpeedChangingArrows
{
    public class rhythmArrows : ASpeedChangingArrow
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                levelManager.SetPlayerMode("Rhythm");
                this.UpdatePlayerSpeed();
            }
        }
    }
}
