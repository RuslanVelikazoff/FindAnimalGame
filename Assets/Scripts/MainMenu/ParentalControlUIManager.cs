using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ParentalControlUIManager : MonoBehaviour
    {
        [Header("Панели")]
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject parentalControllPanel;

        [Space(7)]

        [Header("Меню родительского контроля")]
        [SerializeField] private Button openParrentalControllButton;
        [SerializeField] private GameObject openParrentalControllObject;
        [SerializeField] private Button[] numberButtons;
        [SerializeField] private Button acceptButton;
        [SerializeField] private Button clearButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private Text textAge;
        [SerializeField] private int currentYear;

        [Header("Дополнительные компоненты")]
        private Data.StartData data;
        private UI.MenuUIManager menuUIManager;

        public void Initialize(Data.StartData Data, UI.MenuUIManager MenuUIManager)
        {
            data = Data;
            menuUIManager = MenuUIManager;

            CheckActiveButton();
            ButtonFunc();
            NumberButtonsFunc();

            Debug.Log("ParentalControllerUI initialized");
        }

        private void CheckActiveButton()
        {
            if (data._fullGame)
            {
                openParrentalControllObject.SetActive(false);
            }
            else
            {
                openParrentalControllObject.SetActive(true);
            }
        }

        private void NumberButtonsFunc()
        {
            if (numberButtons[0] != null)
            {
                numberButtons[0].onClick.RemoveAllListeners();
                numberButtons[0].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "0";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
            if (numberButtons[1] != null)
            {
                numberButtons[1].onClick.RemoveAllListeners();
                numberButtons[1].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "1";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
            if (numberButtons[2] != null)
            {
                numberButtons[2].onClick.RemoveAllListeners();
                numberButtons[2].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "2";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
            if (numberButtons[3] != null)
            {
                numberButtons[3].onClick.RemoveAllListeners();
                numberButtons[3].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "3";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
            if (numberButtons[4] != null)
            {
                numberButtons[4].onClick.RemoveAllListeners();
                numberButtons[4].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "4";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
            if (numberButtons[5] != null)
            {
                numberButtons[5].onClick.RemoveAllListeners();
                numberButtons[5].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "5";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
            if (numberButtons[6] != null)
            {
                numberButtons[6].onClick.RemoveAllListeners();
                numberButtons[6].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "6";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
            if (numberButtons[7] != null)
            {
                numberButtons[7].onClick.RemoveAllListeners();
                numberButtons[7].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "7";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
            if (numberButtons[8] != null)
            {
                numberButtons[8].onClick.RemoveAllListeners();
                numberButtons[8].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "8";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
            if (numberButtons[9] != null)
            {
                numberButtons[9].onClick.RemoveAllListeners();
                numberButtons[9].onClick.AddListener(() =>
                {
                    if (textAge.text.Length < 4)
                    {
                        textAge.text += "9";
                    }
                    else
                    {
                        textAge.text += "";
                    }
                });
            }
        }

        private void ButtonFunc()
        {
            if (openParrentalControllButton != null)
            {
                openParrentalControllButton.onClick.RemoveAllListeners();
                openParrentalControllButton.onClick.AddListener(() =>
                {
                    menuPanel.SetActive(false);
                    parentalControllPanel.SetActive(true);
                });
            }

            if(closeButton != null)
            {
                closeButton.onClick.RemoveAllListeners();
                closeButton.onClick.AddListener(() =>
                {
                    menuPanel.SetActive(true);
                    parentalControllPanel.SetActive(false);
                });
            }

            if (clearButton != null)
            {
                clearButton.onClick.RemoveAllListeners();
                clearButton.onClick.AddListener(() =>
                {
                    Debug.Log("Buton is okay");
                    textAge.text = "";
                });
            }

            if (acceptButton != null)
            {
                acceptButton.onClick.RemoveAllListeners();
                acceptButton.onClick.AddListener(() =>
                {
                    CheckAge();
                    menuPanel.SetActive(true);
                    parentalControllPanel.SetActive(false);
                });
            }
        }

        private void CheckAge()
        {
            int Age = int.Parse(textAge.text);

            if (currentYear - Age < 18 || currentYear - Age > 99)
            {
                Debug.Log("Bad");
            }
            else
            {
                Debug.Log("Good");
                data._fullGame = true;
                parentalControllPanel.SetActive(false);
                menuPanel.SetActive(true);
                CheckActiveButton();
                menuUIManager.SetLevelsSprites();
            }
            //TODO: добавить пасхалку
        }
    }
}
