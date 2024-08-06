using UnityEngine;

namespace BossFight.Cyber
{
    public class NPCDriverSpawner : MonoBehaviour
    {
        [SerializeField] private float numberNPCToSpawn;
        [SerializeField] private float minNPCVelocity;
        [SerializeField] private float maxNPCVelocity;
        [SerializeField] private StreetBounds streetBounds;
        
        [SerializeField] private GameObject npcDriverPrefab;
        [SerializeField] private NPCDriver npcDriverPrefabScript;

        private void Start()
        {
            for (int i = 0; i < numberNPCToSpawn; i++)
            {
                SpawnNPCDriver();
            }
        }

        private void SpawnNPCDriver()
        {
            float zPos = Random.Range(streetBounds.GetMinZ(), streetBounds.GetMaxZ());
            float xPos = Random.Range(streetBounds.GetMinX() + (npcDriverPrefabScript.GetMeshWidth() / 2), 
                                      streetBounds.GetMaxX() - (npcDriverPrefabScript.GetMeshWidth() / 2));
            GameObject npc = Instantiate(npcDriverPrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
            npc.GetComponent<NPCDriver>().SetVelocity(Random.Range(minNPCVelocity, maxNPCVelocity));
            
        }
    }
}
