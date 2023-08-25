using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsUIManager : MonoBehaviour
    {
        [Header("Панели")]
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject settingsPanel;

        [Header("Меню настроек")]
        [SerializeField] private Button openSettingsButton;
        [SerializeField] private Button closeSettingsButton;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider soundVolumeSlider;
        [SerializeField] private Slider environmentVolumeSlider;

        public void Initialize()
        {
            SettingsButtonFunc();
            SetSlidersValue();

            Debug.Log("SettingsUI initialized");
        }

        private void Update()
        {
            UpdateVolume();
        }

        private void SetSlidersValue()
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");

            soundVolumeSlider.value = PlayerPrefs.GetFloat("SoundVolume");

            musicVolumeSlider.value = PlayerPrefs.GetFloat("EnvironmentVolume");
        }

        private void UpdateVolume()
        {
            PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
            PlayerPrefs.SetFloat("SoundVolume", soundVolumeSlider.value);
            PlayerPrefs.SetFloat("EnvironmentVolume", environmentVolumeSlider.value);

            foreach (var s in AudioManager.AudioManager.Instance.sounds)
            {
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

        private void SettingsButtonFunc()
        {
            if (openSettingsButton != null)
            {
                openSettingsButton.onClick.RemoveAllListeners();
                openSettingsButton.onClick.AddListener(() =>
                {
                    menuPanel.SetActive(false);
                    settingsPanel.SetActive(true);
                });
            }

            if (closeSettingsButton != null)
            {
                closeSettingsButton.onClick.RemoveAllListeners();
                closeSettingsButton.onClick.AddListener(() =>
                {
                    menuPanel.SetActive(true);
                    settingsPanel.SetActive(false);
                });
            }
        }
    }
}
