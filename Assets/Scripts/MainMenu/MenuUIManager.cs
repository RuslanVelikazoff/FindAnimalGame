using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MenuUIManager : MonoBehaviour
    {
        [Header("Панели")]
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject parentalControlPanel;

        [Header("Главное меню")]
        [SerializeField] private Button[] levelsButtons;
        [SerializeField] private Image[] levelsImages;
        [SerializeField] private Sprite[] levelsSprites;
        [SerializeField] private Sprite closeLevelSprite;
        [SerializeField] private Button exitGameButton;

        [Space(7)]

        [Header("Дополнительные компоненты")]
        private Data.StartData data;
        private Animation.UIAnimation UIAnimation;

        public void Initialize(Data.StartData Data, Animation.UIAnimation uIAnimation)
        {
            data = Data;
            UIAnimation = uIAnimation;

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

            if (levelsButtons[3] != null)
            {
                levelsButtons[3].onClick.RemoveAllListeners();
                levelsButtons[3].onClick.AddListener(() =>
                {
                    if (data._fullGame)
                    {
                        SceneManager.LoadScene(4);
                    }
                    else
                    {
                        UIAnimation.OpenPanel(mainPanel, parentalControlPanel);
                    }
                });
            }
            
            if (levelsButtons[4] != null)
            {
                levelsButtons[4].onClick.RemoveAllListeners();
                levelsButtons[4].onClick.AddListener(() =>
                {
                    if (data._fullGame)
                    {
                        SceneManager.LoadScene(5);
                    }
                    else
                    {
                        UIAnimation.OpenPanel(mainPanel, parentalControlPanel);
                    }
                });
            }
            
            if (levelsButtons[5] != null)
            {
                levelsButtons[5].onClick.RemoveAllListeners();
                levelsButtons[5].onClick.AddListener(() =>
                {
                    if (data._fullGame)
                    {
                        SceneManager.LoadScene(6);
                    }
                    else
                    {
                        UIAnimation.OpenPanel(mainPanel, parentalControlPanel);
                    }
                });
            }
            
            if (levelsButtons[6] != null)
            {
                levelsButtons[6].onClick.RemoveAllListeners();
                levelsButtons[6].onClick.AddListener(() =>
                {
                    if (data._fullGame)
                    {
                        SceneManager.LoadScene(7);
                    }
                    else
                    {
                        UIAnimation.OpenPanel(mainPanel, parentalControlPanel);
                    }
                });
            }
            
            if (levelsButtons[7] != null)
            {
                levelsButtons[7].onClick.RemoveAllListeners();
                levelsButtons[7].onClick.AddListener(() =>
                {
                    if (data._fullGame)
                    {
                        SceneManager.LoadScene(8);
                    }
                    else
                    {
                        UIAnimation.OpenPanel(mainPanel, parentalControlPanel);
                    }
                });
            }
            
            if (levelsButtons[8] != null)
            {
                levelsButtons[8].onClick.RemoveAllListeners();
                levelsButtons[8].onClick.AddListener(() =>
                {
                    if (data._fullGame)
                    {
                        SceneManager.LoadScene(9);
                    }
                    else
                    {
                        UIAnimation.OpenPanel(mainPanel, parentalControlPanel);
                    }
                });
            }
            
            if (levelsButtons[9] != null)
            {
                levelsButtons[9].onClick.RemoveAllListeners();
                levelsButtons[9].onClick.AddListener(() =>
                {
                    if (data._fullGame)
                    {
                        SceneManager.LoadScene(10);
                    }
                    else
                    {
                        UIAnimation.OpenPanel(mainPanel, parentalControlPanel);
                    }
                });
            }
        }
    }
}
