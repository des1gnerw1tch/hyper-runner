using System.Collections.Generic;
using UnityEngine;
using Utils.List;

// Handles activating dance tiles for the user to interact with during Dance mode.
public class danceTileManager : MonoBehaviour {
    private IDanceObject activeDanceObj;
    [SerializeField] private RhythmMovement rhythmMovement;

    private Queue<ADanceObject> danceTileQueue;

    public static danceTileManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
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
        }
    }
    
    // Enables next dance key in queue to receive input. 
    public void EnableNextDanceKey(bool teleportToNextDanceKey = true) {
        if (danceTileQueue.Count < 1)
        {
            Debug.Log("No more dance keys, this should mean this was the last dance key in the level!");
            return;
        }
        
        if (teleportToNextDanceKey)
        {
            rhythmMovement.StartVerticalMovement(danceTileQueue.Peek().transform.position);
        }
        activeDanceObj = danceTileQueue.Peek();
        danceTileQueue.Dequeue();
    }

    public Vector3 GetNextDanceKeyPosition() => danceTileQueue.Peek().transform.position;

    // INPUT DELEGATION TO DANCE TILE
    public void OnUpDanceKeyPress() {
        activeDanceObj.OnUpDanceKeyPress();
    }

    public void OnUpDanceKeyRelease() {
        activeDanceObj.OnUpDanceKeyRelease();
    }

    public void OnDownDanceKeyPress() {
        activeDanceObj.OnDownDanceKeyPress();
    }

    public void OnDownDanceKeyRelease() {
        activeDanceObj.OnDownDanceKeyRelease();
    }

    public void OnLeftDanceKeyPress() {
        activeDanceObj.OnLeftDanceKeyPress();
    }

    public void OnLeftDanceKeyRelease() {
        activeDanceObj.OnLeftDanceKeyRelease();
    }

    public void OnRightDanceKeyPress() {
        activeDanceObj.OnRightDanceKeyPress();
    }

    public void OnRightDanceKeyRelease() {
        activeDanceObj.OnRightDanceKeyRelease();
    }

    public void OnAnyDanceKeyPress() {
        activeDanceObj.OnAnyDanceKeyPress();
    }

}
