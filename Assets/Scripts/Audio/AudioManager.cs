using System;
using UnityEngine;
//TODO: починить музыку
namespace AudioManager
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);

            SetVolume();
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning($"Sound {name} not found!");
                return;
            }
            s.source.Play();
        }

        public void Pause(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning($"Sound {name} not founded!");
                return;
            }
            s.source.Pause();
        }

        private void SetVolume()
        {
            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.pitch = s.pitch = 1;
                s.source.loop = s.loop;

                s.source.volume = s.volume = PlayerPrefs.GetFloat("SoundVolume");

                if (s.name == "Music")
                {
                    s.source.volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
                }

                if (s.name == "Forest"
                    || s.name == "Safari"
                    || s.name == "Pet"
                    || s.name == "Aquarium"
                    || s.name == "Village"
                    || s.name == "Pond"
                    || s.name == "Birds"
                    || s.name == "Jungle"
                    || s.name == "Arctic"
                    || s.name == "Arc")
                {
                    s.source.volume = s.volume = PlayerPrefs.GetFloat("EnvironmentVolume");
                }
            }
        }
    }


}
