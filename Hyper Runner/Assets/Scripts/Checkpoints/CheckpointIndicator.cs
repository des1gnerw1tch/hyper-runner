using SpriteVisualEffects;
using UnityEngine;

namespace Checkpoints
{
    /// <summary>
    /// This is a small sprite that is spawned at the position Lakitu will place the player at. This lets the player know where they are going
    /// to be placed after running into an object or falling in platform mode. 
    /// </summary>
    public class CheckpointIndicator : MonoBehaviour
    {
        [SerializeField] private AlphaFade fade;

        private void Start() => fade.SetSpriteAlpha(0);

        public void Activate(Vector3 posToSpawnAt)
        {
            transform.position = posToSpawnAt;
            fade.StartCycleFade(.3f);
        }

        public void Disable() => fade.StopCycleFade(false);
    }
}
