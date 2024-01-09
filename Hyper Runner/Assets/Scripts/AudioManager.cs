using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake() {
        foreach (Sound s in sounds) {
            if (s.objectToAttachSourceTo == null)
            {
                s.source = gameObject.AddComponent<AudioSource>();
            }
            else
            {
                // For 3D sounds
                s.source = s.objectToAttachSourceTo.AddComponent<AudioSource>();
                s.source.spatialBlend = s.spatialBlend3D;
                s.source.rolloffMode = AudioRolloffMode.Linear;
                s.source.minDistance = s.minDistance;
                s.source.maxDistance = s.maxDistance;
            }
            
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            if (s.playOnAwake)
            {
                s.source.Play();
            }
        }
    }

    //this is for sound effects
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!SoundNameIsNull(s, name))
        {
            s.source.Play();
        }
        
    }

    // this is to play sound effect with certain pitch
    public void Play(string name, float pitch) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!SoundNameIsNull(s, name))
        {
            s.source.pitch = pitch;
            s.source.Play();
        }
    }

    // resets the pitch of a audio source
    public void ResetPitch(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!SoundNameIsNull(s, name))
        {
            s.source.pitch = s.pitch;
        }
    }

    //this is to play music
    public void PlayTheme(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!SoundNameIsNull(s, name))
        {
            s.source.Play();
        }
    }

    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!SoundNameIsNull(s, name))
        {
            s.source.Stop();
        }
    }

    /// <summary>
    /// Changes the volume of a sound currently playing. Does not handle multiple of the same sound
    /// playing at once.
    /// </summary>
    /// <param name="name"> name of sound</param>
    /// <param name="newVolume"> volume (between 0-1) to change audio clip to</param>
    /// <returns>Previous volume level</returns>
    public float ChangeVolume(string name, float newVolume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!SoundNameIsNull(s, name))
        {
            float oldVol = s.source.volume;
            s.source.volume = newVolume;
            return oldVol;
        }
        return -1;
    }

    /// <summary>
    /// Gets the audio clip length in seconds of a currently playing sound. Does not handle
    /// sounds that are not currently playing. 
    /// </summary>
    /// <param name="name">name of sound</param>
    /// <returns> clip length in seconds</returns>
    public float GetAudioClipLength(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!SoundNameIsNull(s, name))
        {
            return s.GetLength();
        }
        return -1;
    }

    public void Pause(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!SoundNameIsNull(s, name))
        {
            s.source.Pause();
        }
    }

    private bool SoundNameIsNull(Sound s, string soundName)
    {
        if (s == null)
        {
            Debug.LogError("Sound " + soundName + " not found");
            return true;
        }

        return false;
    }
}
