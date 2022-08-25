using System.Collections.Generic;
using UnityEngine;

namespace Checkpoints
{
    /// <summary>
    /// Holds all of the checkpoints in the scene.
    /// </summary>
    public class CheckpointManager : MonoBehaviour
    {
        [Header("Checkpoints should be a child of this object.")]
        [SerializeField] private List<Transform> activeCheckpoints;
        
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
