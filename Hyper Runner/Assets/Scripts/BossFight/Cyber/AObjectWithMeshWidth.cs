using UnityEngine;

namespace BossFight.Cyber
{
    public abstract class AObjectWithMeshWidth : MonoBehaviour
    {
        [SerializeField] private float meshWidth;
        
        public float GetMeshWidth() => meshWidth;
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(this.transform.position, new Vector3(meshWidth, 1, 1));
        }
    }
}
