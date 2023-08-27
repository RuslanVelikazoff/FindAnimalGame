using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelUIManager : MonoBehaviour
    {
        [Header("Кнопки интерфейса")] 
        [SerializeField] private Button exitLevelButton;
        [SerializeField] private Button nextLevelButton;

        [Space(7)] 
        
        [Header("Кнопки животных")] 
        [SerializeField] private Button[] animalsButton;

        [Space(7)]
        
        [Header("Текст")] 
        [SerializeField] private Text findText;
        [SerializeField] private Text animalText;

        [Space(7)] 
        
        [Header("Игровые объекты")] 
        [SerializeField] private GameObject[] gameObjects;
        [SerializeField] private GameObject nextLevel;

        [Space(7)] [Header("Дополнительные объекты")]
        private LevelManager levelManager;
        
        public void Initialize(LevelManager LevelManager)
        {
            levelManager = LevelManager;
            ButtonsFunc();
            AnimalsButtonsFunc();

            Debug.Log("LevelUI initialized");
        }

        private void AnimalsButtonsFunc()
        {
            if (animalsButton[0] != null)
            {
                animalsButton[0].onClick.RemoveAllListeners();
                animalsButton[0].onClick.AddListener(() =>
                {
                    levelManager.CheckAnimal(0);
                });
            }

            if (animalsButton[1] != null)
            {
                animalsButton[1].onClick.RemoveAllListeners();
                animalsButton[1].onClick.AddListener(() =>
                {
                    levelManager.CheckAnimal(1);
                });
            }

            if (animalsButton[2] != null)
            {
                animalsButton[2].onClick.RemoveAllListeners();
                animalsButton[2].onClick.AddListener(() =>
                {
                    levelManager.CheckAnimal(2);
                });
            }
        }

        private void ButtonsFunc()
        {
            if (exitLevelButton != null)
            {
                exitLevelButton.onClick.RemoveAllListeners();
                exitLevelButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(0);
                });
            }

            if (nextLevelButton != null)
            {
                nextLevelButton.onClick.RemoveAllListeners();
                nextLevelButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                });
            }
        }

        public void ShowUI(bool status, int nextLevelCount, int level)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(status);
            }

            if (nextLevelCount < 5 || level == 10)
            {
                nextLevel.SetActive(false);
            }
        }

        public void SetExerciseText(string animalName)
        {
            animalText.text = animalName;
        }
    }
}
