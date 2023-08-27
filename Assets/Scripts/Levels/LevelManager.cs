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

    public void CheckAnimal(int exercise)
    {
        StartCoroutine(CheckAnimalCO(exercise));
    }
    
    public IEnumerator CheckAnimalCO(int exercise)
    {
        if (exercise == exerciseIndex)
        {
            Debug.Log("Good");
            levelUiManager.ShowUI(false, nextLevelCount, levelIndex);
            animalAnimations[exercise].StartAnimation(world.levels[levelIndex].durationsAnimations[exerciseIndex]);

            yield return new WaitForSeconds(world.levels[levelIndex].durationsAnimations[exerciseIndex]);
            
            SetExerciseText();
            nextLevelCount++;
            levelUiManager.ShowUI(true, nextLevelCount, levelIndex);
        }
        else
        {
            Debug.Log("Bad");
        }
    }
}
