using UnityEngine;

namespace BossFight.Cyber
{
    public class NPCDriver : MonoBehaviour
    {
        [SerializeField] private float velocity;
        [SerializeField] private float meshWidth;

        private void Update() => this.transform.Translate(Vector3.back * velocity *  Time.deltaTime);
        
        public float GetMeshWidth() => meshWidth;
        
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(this.transform.position, new Vector3(meshWidth, 1, 1));
        }

        public void SetVelocity(float v) => velocity = v;
    }
}
