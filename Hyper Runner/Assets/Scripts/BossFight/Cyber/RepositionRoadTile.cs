using UnityEngine;

namespace BossFight.Cyber
{
    public class RepositionRoadTile : MonoBehaviour
    {
        [SerializeField] private Transform teleportPoint;
        [SerializeField] private float teleportDistance;

        [SerializeField] private Transform player;

        private void Update()
        {
            if (player.position.z < teleportPoint.position.z)
            {
                this.transform.position -= Vector3.back * teleportDistance;
            }
        }
    }
}
