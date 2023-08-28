using UnityEngine;

namespace Loader
{
    public class MenuLoader : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private UI.MenuUIManager menuUIManager;
        [SerializeField] private UI.SettingsUIManager settingsUIManager;
        [SerializeField] private UI.ParentalControlUIManager parentalControlUIManager;

        [Space(7)]
        [Header("Animation")]
        [SerializeField] private Animation.FullGameButton fullGameButton;
        private Animation.UIAnimation UIAnimation;

        [Space(7)]

        [Header("Data")]
        [SerializeField] private Data.StartData data;

        void Start()
        {
            data.Initialize();
            UIAnimation = new Animation.UIAnimation();
            AudioManager.AudioManager.Instance.Play("Theme");
            settingsUIManager.Initialize(UIAnimation);
            menuUIManager.Initialize(data, UIAnimation);
            parentalControlUIManager.Initialize(data, menuUIManager, UIAnimation);
            fullGameButton.Initialize(data);
        }
    }
}
