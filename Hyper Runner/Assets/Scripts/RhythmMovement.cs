using UnityEngine;

public class RhythmMovement : MonoBehaviour {
    [HideInInspector] public float speed; // Set in ALevelManager
    private bool isLaunchingFromRhythmArrows;
    private float verticalLaunchSpeed;
    [SerializeField] private Animator animatorComponent;
    [SerializeField] private RuntimeAnimatorController rhythmAnimator;
    [SerializeField] private GameObject flyingParticles;

    // For vertical movement (bouncing between rhythm tiles)
    private Vector3? lastPosition = null;
    private Vector3? nextTilePosition = null;

    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x + speed * MusicSync.deltaSample;
        float yPos;

        if (lastPosition.HasValue && nextTilePosition.HasValue)
        {
            // If we just launched from rhythm arrows, vertical speed can be controlled with verticalLaunchSpeed
            if (isLaunchingFromRhythmArrows)
            { 
                yPos = transform.position.y + verticalLaunchSpeed * MusicSync.deltaSample;
                if (yPos > nextTilePosition.Value.y)
                {
                    yPos = nextTilePosition.Value.y;
                    animatorComponent.runtimeAnimatorController = rhythmAnimator;
                    lastPosition = transform.position;
                    isLaunchingFromRhythmArrows = false;
                }
            }
            // If not, vertical speed is lerped
            else
            {
                float totalXDistanceToCover = nextTilePosition.Value.x - lastPosition.Value.x;
                float currentXDistanceCovered = transform.position.x - lastPosition.Value.x;
                float fracDistanceCovered = currentXDistanceCovered / totalXDistanceToCover;
                yPos = Mathf.Lerp(lastPosition.Value.y, nextTilePosition.Value.y, fracDistanceCovered);
            }
        }
        else
        {
            yPos = transform.position.y;
            Debug.LogError("Next and/or Last tile positions are null.");
        }
        
        transform.position = new Vector3(xPos, yPos, 0);
    }

    // startRhythm : Float -> will move player
    // When called will over time kick the player into position to hit first dance tile.

    public void startRhythm(float teleSpeed) {
        Debug.Log("Started teleporting");
        flyingParticles.SetActive(true);
        isLaunchingFromRhythmArrows = true;
        verticalLaunchSpeed = teleSpeed;
        Vector3 tile = danceTileManager.Instance.GetActiveDanceKeyPosition();
        StartVerticalMovement(tile);
    }

    public void DeactivateFlyingParticles()
    {
        flyingParticles.SetActive(false);
    }

    // Sets up vertical movement for character. Creates a bouncing between dance tiles effect.
    public void StartVerticalMovement(Vector3 nextTilePosition)
    {
        lastPosition = transform.position;
        this.nextTilePosition =  nextTilePosition;
    }
}
