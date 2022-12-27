using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkpoints
{
    /// <summary>
    /// Holds all of the checkpoints in the scene. Also deals with Lakitu, who helps the player get back on track when player runs into
    /// object in platforming mode. 
    /// </summary>
    public class CheckpointManager : MonoBehaviour
    {
        [Header("Checkpoints should be a child of this object.")]
        [SerializeField] private List<Transform> activeCheckpoints;
        [SerializeField] private GameObject myLakitu;

        private Coroutine lakituFollowPlayer;
        private const float LAKITU_Y_OFFSET_FROM_PLAYER = 1f;
        
        public static CheckpointManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        
        public void UpdateCheckpoints()
        {
            activeCheckpoints.Clear();
            
            foreach (Transform child in transform)
            {
                if (child.gameObject == myLakitu)
                {
                    continue;
                }
                activeCheckpoints.Add(child);
            }
            
            activeCheckpoints.Sort(new TransformXComparer());
        }

        // Finds the closest checkpoint ahead of xPos, and deletes previous checkpoints from list. This assumes that checkpoints in list are sorted.
        public Vector3? FindNearestCheckpoint(float xPos)
        {
            for (int i = 0; i < activeCheckpoints.Count; i++)
            {
                if (activeCheckpoints[i].position.x > xPos)
                {
                    Vector3 solution = activeCheckpoints[i].position;
                    activeCheckpoints.RemoveRange(0, i + 1);
                    return solution;
                }
            }
            
            return null;
        }

        // Activates Lakitu behavior to follow player, and then leave after the player is set.
        public void ActivateLakitu()
        {
            myLakitu.SetActive(true);
            Transform player = GameObject.FindWithTag("Player").transform;
            lakituFollowPlayer = StartCoroutine(FollowPlayer());
            
            // Lakitu will follow the player here
            IEnumerator FollowPlayer()
            {
                while (true)
                {
                    Vector3 playerPos = player.position;
                    Vector3 lakituPosition = new Vector3(playerPos.x, playerPos.y + LAKITU_Y_OFFSET_FROM_PLAYER, 0);
                    myLakitu.transform.position = lakituPosition;
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        public void DeactivateLakitu()
        {
            if (lakituFollowPlayer == null)
            {
                Debug.LogError("lakitu follow player coroutine is null. This should not happen.");
                return;
            }
            StopCoroutine(lakituFollowPlayer);
            myLakitu.SetActive(false);
        }
        
        /// <summary>
        /// Transform position X axis comparer.
        /// </summary>
        private class TransformXComparer : IComparer<Transform>
        {
            public int Compare(Transform t1, Transform t2)
            {
                if (t1.position.x <= t2.position.x)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

    }

    
    
}
