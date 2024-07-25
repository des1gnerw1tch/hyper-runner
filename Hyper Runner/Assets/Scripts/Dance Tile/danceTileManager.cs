using System.Collections.Generic;
using UnityEngine;
using Utils.List;

// Handles activating dance tiles for the user to interact with during Dance mode.
public class danceTileManager : MonoBehaviour {
    private IDanceObject activeDanceObj;
    private Vector3 activeDanceObjPos;
    [SerializeField] private RhythmMovement rhythmMovement;
    private bool hasLastTileBeenDestroyed = false;

    private Queue<ADanceObject> danceTileQueue;

    public static danceTileManager Instance { get; private set; }

    // The starting dance tile positions. These are saved at the start so player can "bounce" to other dance tiles, even if the dance tiles are moving. 
    private readonly Dictionary<GameObject, Vector3> tileStartingPositions = new Dictionary<GameObject, Vector3>();
    
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

    private void Start()
    {
        AddDanceTilesInSceneToQueue();
        EnableNextDanceKey(teleportToNextDanceKey: false);
    }

    private void AddDanceTilesInSceneToQueue()
    {
        GameObject[] danceGameObjs = GameObject.FindGameObjectsWithTag("DanceTile");
        List<Transform> danceTransforms = new List<Transform>();
        foreach (GameObject obj in danceGameObjs)
        {
            danceTransforms.Add(obj.transform);
        }
        
        danceTransforms.Sort(new TransformXComparer());
        danceTileQueue = new Queue<ADanceObject>();
        foreach (Transform obj in danceTransforms)
        {
            danceTileQueue.Enqueue(obj.GetComponent<ADanceObject>());
            tileStartingPositions.Add(obj.gameObject, obj.position);
        }
    }
    
    // Enables next dance key in queue to receive input. 
    public void EnableNextDanceKey(bool teleportToNextDanceKey = true) {
        if (danceTileQueue.Count < 1)
        {
            hasLastTileBeenDestroyed = true;
            Debug.Log("No more dance keys, this should mean this was the last dance key in the level!");
            return;
        }
        
        if (teleportToNextDanceKey)
        {
            GameObject nextTile = danceTileQueue.Peek().gameObject;
            Vector3 teleportPos = tileStartingPositions[nextTile];
            rhythmMovement.StartVerticalMovement(teleportPos);
        }
        activeDanceObj = danceTileQueue.Peek();
        activeDanceObjPos = danceTileQueue.Peek().transform.position;
        danceTileQueue.Dequeue();
    }

    public Vector3 GetActiveDanceKeyPosition() => activeDanceObjPos;

    // INPUT DELEGATION TO DANCE TILE
    public void OnUpDanceKeyPress() {
        if (hasLastTileBeenDestroyed)
        {
            return;
        }
        activeDanceObj.OnUpDanceKeyPress();
    }

    public void OnUpDanceKeyRelease() {
        if (hasLastTileBeenDestroyed)
        {
            return;
        }
        activeDanceObj.OnUpDanceKeyRelease();
    }

    public void OnDownDanceKeyPress() {
        if (hasLastTileBeenDestroyed)
        {
            return;
        }
        
        activeDanceObj.OnDownDanceKeyPress();
    }

    public void OnDownDanceKeyRelease() {
        if (hasLastTileBeenDestroyed)
        {
            return;
        }
        activeDanceObj.OnDownDanceKeyRelease();
    }

    public void OnLeftDanceKeyPress() {
        if (hasLastTileBeenDestroyed)
        {
            return;
        }
        activeDanceObj.OnLeftDanceKeyPress();
    }

    public void OnLeftDanceKeyRelease() {
        if (hasLastTileBeenDestroyed)
        {
            return;
        }
        activeDanceObj.OnLeftDanceKeyRelease();
    }

    public void OnRightDanceKeyPress() {
        if (hasLastTileBeenDestroyed)
        {
            return;
        }
        activeDanceObj.OnRightDanceKeyPress();
    }

    public void OnRightDanceKeyRelease() {
        if (hasLastTileBeenDestroyed)
        {
            return;
        }
        activeDanceObj.OnRightDanceKeyRelease();
    }

    public void OnAnyDanceKeyPress() {
        if (hasLastTileBeenDestroyed)
        {
            return;
        }
        activeDanceObj.OnAnyDanceKeyPress();
    }

}
