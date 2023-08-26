using UnityEngine;
using UnityEngine.SceneManagement;
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
            ButtonFunc();

            Debug.Log("MenuUIManager initialized");
        }

        private void ButtonFunc()
        {
            LevelsButtonsFunc();
            
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

        private void LevelsButtonsFunc()
        {
            if (levelsButtons[0] != null)
            {
                levelsButtons[0].onClick.RemoveAllListeners();
                levelsButtons[0].onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(1);
                });
            }

            if (levelsButtons[1] != null)
            {
                levelsButtons[1].onClick.RemoveAllListeners();
                levelsButtons[1].onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(2);
                });
            }

            if (levelsButtons[2] != null)
            {
                levelsButtons[2].onClick.RemoveAllListeners();
                levelsButtons[2].onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(3);
                });
            }
        }
    }
}
