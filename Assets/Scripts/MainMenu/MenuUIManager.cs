using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuUIManager : MonoBehaviour
    {
        [Header("Главное меню")]
        [SerializeField] private Button[] levelsButtons;
        [SerializeField] private Image[] levelsImages;
        [SerializeField] private Sprite[] levelsSprites;
        [SerializeField] private Sprite closeLevelSprite;
        [SerializeField] private Button exitGameButton;

        [Space(7)]

        [Header("Дополнительные компоненты")]
        private Data.StartData data;

        public void Initialize(Data.StartData Data)
        {
            data = Data;

            SetLevelsSprites();
            LevelButtonFunc();

            Debug.Log("MenuUIManager initialized");
        }

        private void LevelButtonFunc()
        {
            if (exitGameButton != null)
            {
                exitGameButton.onClick.RemoveAllListeners();
                exitGameButton.onClick.AddListener(() =>
                {
                    Debug.Log("Exit Game");
                    Application.Quit();
                });
            }
        }

        public void SetLevelsSprites()
        {
            if (data._fullGame)
            {
                for (int i = 0; i < levelsImages.Length; i++)
                {
                    levelsImages[i].sprite = levelsSprites[i];
                }
            }

            else
            {
                for (int i = 0; i < levelsImages.Length; i++)
                {
                    if (i <= 2)
                    {
                        levelsImages[i].sprite = levelsSprites[i];
                    }
                    else
                    {
                        levelsImages[i].sprite = closeLevelSprite;
                    }
                }
            }
        }
    }
}
