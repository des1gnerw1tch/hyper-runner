using System.Data;
using UnityEngine;

/**
 * This will take two tiles, and "wind" them up after tile sorting is completed. Then when the player gets close, the tiles will unwind into the
 * correct positions.
 */
public class SwapDanceTilesObject : MonoBehaviour
{
    [SerializeField] private Transform pivot;

    [SerializeField] private float distanceStartUnwind;
    [SerializeField] private float distanceFinishUnwind;
    private Transform player;
    
    private const float STARTING_Z_ROTATION = 180f;
    private const float ENDING_Z_ROTATION = 0f;

    private bool areTilesUnwinded;

    private bool firstUpdateCallComplete;
    private void Start()
    {
        firstUpdateCallComplete = false;
        
        areTilesUnwinded = false;
        if (distanceStartUnwind <= distanceFinishUnwind)
        {
            throw new ConstraintException("Distance start unwind must be greater than distance to finish unwind");
        }
        
        player = GameObject.FindWithTag("Player").transform;
    }

    private void WindRhythmTiles()
    {
        Debug.Log("Rotated!");
        pivot.eulerAngles = new Vector3(0, 0, STARTING_Z_ROTATION);
    } 

    private void Update()
    {
        if (!firstUpdateCallComplete)
        {
            WindRhythmTiles();
            firstUpdateCallComplete = true;
        }
        
        if (areTilesUnwinded)
        {
            return;
        }
        
        float distAway = pivot.position.x - player.position.x;
        if (distAway < distanceFinishUnwind)
        {
            pivot.eulerAngles = new Vector3(0, 0, 0);
            areTilesUnwinded = true;
        }
        else if (distAway < distanceStartUnwind)
        {
            float normalized = Mathf.Clamp(1 - ((distAway - distanceFinishUnwind) / (distanceStartUnwind - distanceFinishUnwind)), 0, 1);
            float angle = Mathf.Lerp(STARTING_Z_ROTATION, ENDING_Z_ROTATION, normalized);
            print(this.gameObject.GetInstanceID() + "ANGLE: " + angle);
            pivot.eulerAngles = new Vector3(0, 0, angle);

        }
    }


}
