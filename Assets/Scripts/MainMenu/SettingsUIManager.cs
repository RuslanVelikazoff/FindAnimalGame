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

        [Header("Дополнительные компоненты")]
        Animation.UIAnimation UIAnimation;
        
        public void Initialize(Animation.UIAnimation uiAimation)
        {
            UIAnimation = uiAimation;

            AudioManager.AudioManager.Instance.InitializeVolume(soundVolumeSlider, musicVolumeSlider, environmentVolumeSlider);

            SettingsButtonFunc();

            Debug.Log("SettingsUI initialized");
        }

        private void Update()
        {
            AudioManager.AudioManager.Instance.UpdateVolume(soundVolumeSlider, musicVolumeSlider, environmentVolumeSlider);
        }

        private void SettingsButtonFunc()
        {
            if (openSettingsButton != null)
            {
                openSettingsButton.onClick.RemoveAllListeners();
                openSettingsButton.onClick.AddListener(() =>
                {
                    UIAnimation.OpenPanel(menuPanel, settingsPanel);
                    //menuPanel.SetActive(false);
                    //settingsPanel.SetActive(true);
                });
            }

            if (closeSettingsButton != null)
            {
                closeSettingsButton.onClick.RemoveAllListeners();
                closeSettingsButton.onClick.AddListener(() =>
                {
                    UIAnimation.OpenPanel(settingsPanel, menuPanel);
                    //menuPanel.SetActive(true);
                    //settingsPanel.SetActive(false);
                });
            }
        }
    }
}
