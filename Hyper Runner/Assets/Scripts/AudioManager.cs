using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake() {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
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
