using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private World world;

    private int levelIndex;
    private int exerciseIndex;
    private int nextLevelCount = 0;
    
    [Header("Дополнительные объекты")] 
    private UI.LevelUIManager levelUiManager;
    private Animation.AnimalAnimations[] animalAnimations;

    public void Initialize(UI.LevelUIManager LevelUiManager, Animation.AnimalAnimations[] AnimalAnimations)
    {
        levelUiManager = LevelUiManager;
        animalAnimations = AnimalAnimations;

        levelIndex = SceneManager.GetActiveScene().buildIndex - 1;

        SetExerciseText();
        
        Debug.Log("LevelManager initialized");
    }

    public void SetExerciseText()
    {
        int lastIndex = exerciseIndex;
        exerciseIndex = Random.Range(0, 3);
        
        if (exerciseIndex == lastIndex)
        {
            SetExerciseText();
        }
        else
        {
            levelUiManager.SetExerciseText(world.levels[levelIndex].animalName[exerciseIndex]);
        }
    }

    public void CheckAnimal(int exercise, float duration)
    {
        StartCoroutine(CheckAnimalCO(exercise, duration));
    }
    
    public IEnumerator CheckAnimalCO(int exercise, float duration)
    {
        if (exercise == exerciseIndex)
        {
            Debug.Log("Good");
            levelUiManager.ShowUI(false, nextLevelCount);
            animalAnimations[exercise].StartAnimation(5f, world.levels[levelIndex].animalName[exerciseIndex]);

            yield return new WaitForSeconds(duration);
            
            SetExerciseText();
            nextLevelCount++;
            levelUiManager.ShowUI(true, nextLevelCount);
        }
        else
        {
            Debug.Log("Bad");
        }
    }
}
