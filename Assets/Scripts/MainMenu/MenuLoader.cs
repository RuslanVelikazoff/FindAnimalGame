using UnityEngine;

namespace Loader
{
    public class MenuLoader : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private UI.MenuUIManager menuUIManager;
        [SerializeField] private UI.SettingsUIManager settingsUIManager;
        [SerializeField] private UI.ParentalControlUIManager parentalControlUIManager;
        [SerializeField] private Animation.FullGameButton fullGameButton;

        [Space(7)]

        [Header("Data")]
        [SerializeField] private Data.StartData data;

        void Start()
        {
            data.Initialize();
            AudioManager.AudioManager.Instance.Play("Theme");
            settingsUIManager.Initialize();
            menuUIManager.Initialize(data);
            parentalControlUIManager.Initialize(data, menuUIManager);
            fullGameButton.Initialize(data);
        }
    }
}
