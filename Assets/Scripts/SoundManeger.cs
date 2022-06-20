using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class SoundManeger : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source= gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.loop;
            s.source.mute = s.Mute;

        }
    }
    public void playSound(string name) {
      Sound s =  Array.Find(sounds, Sound => Sound.name == name);
      if (s == null) return;
      s.source.Play();
    
    }
    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null) return;
        s.source.mute=true;

    }
   
}
