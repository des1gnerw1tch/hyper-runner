using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound  {

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
    
    public bool playOnAwake = false;

    [Header("Optionally attach AudioSource to game object for 3D sounds.")]
    public GameObject objectToAttachSourceTo;
    public float spatialBlend3D = 0;
    public float minDistance = 1;
    public float maxDistance = 20;

    public float GetLength() => clip.length;
}
