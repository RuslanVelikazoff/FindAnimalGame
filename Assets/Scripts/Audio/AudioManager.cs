using System;
using UnityEngine;
using UnityEngine.UI;

namespace AudioManager
{
    public class VolumeNames
    {
        public static string SoundVolume = "SoundVolume";
        public static string MusicVolume = "MusicVolume";
        public static string EnvironmentVolume = "EnvironmentVolume";
    }

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

            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume = PlayerPrefs.GetFloat(VolumeNames.SoundVolume);
                s.source.pitch = 1;
                s.source.loop = s.loop;

                if (s.name == "Theme")
                {
                    s.source.volume = s.volume = PlayerPrefs.GetFloat(VolumeNames.MusicVolume);
                }
            }
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning($"Sound {name} not found!");
                return;
            }
            Debug.Log($"Sound: {name} now played");
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

        public void MinusEnvironmentVolume(string levelName)
        {
            float currentMusicVolume = PlayerPrefs.GetFloat(VolumeNames.MusicVolume);
            float currentEnvironmentVolume = PlayerPrefs.GetFloat(VolumeNames.EnvironmentVolume);

            float newMusicVolume = (currentMusicVolume * 20) / 100;
            float newEnvironmentVolume = (currentEnvironmentVolume * 20) / 100;

            Sound musicSound = Array.Find(sounds, sound => sound.name == "Theme");
            musicSound.source.volume = musicSound.volume = newMusicVolume;

            Sound environmentSound = Array.Find(sounds, sound => sound.name == levelName);
            environmentSound.source.volume = environmentSound.volume = newEnvironmentVolume;
        }

        public void PlusEnvironmentVolume(string levelName)
        {
            float currentMusicVolume = PlayerPrefs.GetFloat(VolumeNames.MusicVolume);
            float currentEnvironmentVolume = PlayerPrefs.GetFloat(VolumeNames.EnvironmentVolume);

            Sound musicSound = Array.Find(sounds, sound => sound.name == "Theme");
            musicSound.source.volume = musicSound.volume = currentMusicVolume;

            Sound environmentSound = Array.Find(sounds, sound => sound.name == levelName);
            environmentSound.source.volume = environmentSound.volume = currentEnvironmentVolume;
        }

        public void UpdateVolume(Slider soundVolumeSlider, Slider musicVolumeSlider, Slider environmentVolumeSlider)
        {
            PlayerPrefs.SetFloat(VolumeNames.SoundVolume, soundVolumeSlider.value);
            PlayerPrefs.SetFloat(VolumeNames.MusicVolume, musicVolumeSlider.value);
            PlayerPrefs.SetFloat(VolumeNames.EnvironmentVolume, environmentVolumeSlider.value);

            foreach (var s in sounds)
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(VolumeNames.SoundVolume);

                if (s.name == "Theme")
                {
                    s.source.volume = s.volume = PlayerPrefs.GetFloat(VolumeNames.MusicVolume);
                }

                if (s.name == "Forest"
               || s.name == "Safari"
               || s.name == "Home"
               || s.name == "Aquarium"
               || s.name == "Village"
               || s.name == "Pond"
               || s.name == "Birds"
               || s.name == "Jungle"
               || s.name == "Arctic"
               || s.name == "Arc")
                {
                    s.source.volume = s.volume = PlayerPrefs.GetFloat(VolumeNames.EnvironmentVolume);
                }
            }
        }

        public void InitializeVolume(Slider soundVolumeSlider, Slider musicVolumeSlider, Slider environmentVolumeSlider)
        {
            if (PlayerPrefs.HasKey(VolumeNames.SoundVolume))
            {
                soundVolumeSlider.value = PlayerPrefs.GetFloat(VolumeNames.SoundVolume);
            }
            else
            {
                soundVolumeSlider.value = 1;
            }

            if (PlayerPrefs.HasKey(VolumeNames.MusicVolume))
            {
                musicVolumeSlider.value = PlayerPrefs.GetFloat(VolumeNames.MusicVolume);
            }
            else
            {
                musicVolumeSlider.value = 1;
            }

            if (PlayerPrefs.HasKey(VolumeNames.EnvironmentVolume))
            {
                environmentVolumeSlider.value = PlayerPrefs.GetFloat(VolumeNames.EnvironmentVolume);
            }
            else
            {
                environmentVolumeSlider.value = 1;
            }
        }

    }
}
