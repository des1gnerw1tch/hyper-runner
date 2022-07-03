using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private string name;
    private AudioManager audio;
    
    void Start()
    {
      audio = FindObjectOfType<AudioManager>();
      audio.PlayTheme(name);
    }

}
