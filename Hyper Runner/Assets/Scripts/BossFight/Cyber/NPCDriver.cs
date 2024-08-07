using UnityEngine;

namespace BossFight.Cyber
{
    public class NPCDriver : AObjectWithMeshWidth
    {
        [SerializeField] private float velocity;

        private void Update() => this.transform.Translate(Vector3.back * velocity *  Time.deltaTime);

        public void SetVelocity(float v) => velocity = v;
    }
}
