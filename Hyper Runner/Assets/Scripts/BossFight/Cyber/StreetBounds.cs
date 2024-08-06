using UnityEngine;

namespace BossFight.Cyber
{
    public class StreetBounds : MonoBehaviour
    {
        [SerializeField] private float width;
        [SerializeField] private float length;

        public void OnDrawGizmosSelected()
        {
            // Draw a yellow cube at the transform position
            Gizmos.color = Color.magenta;
            Vector3 center = new Vector3(transform.position.x, transform.position.y, transform.position.z - (length / 2));
            Gizmos.DrawWireCube(center, new Vector3(width, 1, length));
        }

        public float GetMaxX() => this.transform.position.x + (width / 2);
        public float GetMinX() => this.transform.position.x - (width / 2);
        public float GetMaxZ() => this.transform.position.z + (length / 2);
        public float GetMinZ() => this.transform.position.z - (length / 2);
    }
}
