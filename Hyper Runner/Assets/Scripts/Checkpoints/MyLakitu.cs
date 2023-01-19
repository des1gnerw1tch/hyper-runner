using System.Collections;
using SpriteVisualEffects;
using UnityEngine;

namespace Checkpoints
{
    /**
     * Lakitu, who helps the player get back on track when player runs into object in platforming mode. 
     */
    public class MyLakitu : MonoBehaviour
    {
        [SerializeField] private GameObject meshObject;
        [SerializeField] private Flash flash;
        [SerializeField] private AlphaFade fade;
        [SerializeField] private CheckpointIndicator checkpointIndicator;

        private Coroutine lakituFollowPlayer;
        private const float LAKITU_Y_OFFSET_FROM_PLAYER = 1f;
        
        public static MyLakitu Instance { private set; get; }

        public void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogError("Two MyLakitu instances found. This is a bug that must be fixed.");
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
            
        // Activates Lakitu behavior to follow player, and then leave after the player is set.
        public void ActivateLakitu(Vector3 checkpointPos)
        {
            checkpointIndicator.Activate(checkpointPos);
            
            meshObject.SetActive(true);
            fade.SetSpriteAlpha(1);
            fade.CancelCoroutine();
            flash.StartFlash(Color.white, 3);
            Transform player = GameObject.FindWithTag("Player").transform;
            lakituFollowPlayer = StartCoroutine(FollowPlayer());
            
            // Lakitu will follow the player here
            IEnumerator FollowPlayer()
            {
                while (true)
                {
                    Vector3 playerPos = player.position;
                    Vector3 lakituPosition = new Vector3(playerPos.x, playerPos.y + LAKITU_Y_OFFSET_FROM_PLAYER, 0);
                    meshObject.transform.position = lakituPosition;
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        public void DeactivateLakitu()
        {
            checkpointIndicator.Disable();
            
            if (lakituFollowPlayer == null)
            {
                Debug.LogError("lakitu follow player coroutine is null. This should not happen.");
                return;
            }
            StopCoroutine(lakituFollowPlayer);
            fade.Fade(.5f, 0f, true);
        }
    }
}