using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Уровни")]
    [SerializeField] private World world;

    [Header("Индексы")]
    private int levelIndex;
    private int exerciseIndex;

    [Header("Счётчик")]
    private int nextLevelCount = 0;
    
    [Header("Дополнительные объекты")] 
    private UI.LevelUIManager levelUiManager;
    private Animation.AnimalAnimations[] animalAnimations;

    public void Initialize(UI.LevelUIManager LevelUiManager, Animation.AnimalAnimations[] AnimalAnimations)
    {
        levelUiManager = LevelUiManager;
        animalAnimations = AnimalAnimations;

        levelIndex = SceneManager.GetActiveScene().buildIndex - 1;
        AudioManager.AudioManager.Instance.Play(world.levels[levelIndex].levelName);

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

    public void StopSound()
    {
        AudioManager.AudioManager.Instance.Pause(world.levels[levelIndex].levelName);
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
            AudioManager.AudioManager.Instance.Play("Win");
            AudioManager.AudioManager.Instance.MinusEnvironmentVolume(world.levels[levelIndex].levelName);
            levelUiManager.ShowUI(false, nextLevelCount, levelIndex);
            animalAnimations[exercise].StartAnimation(world.levels[levelIndex].durationsAnimations[exerciseIndex]);

            yield return new WaitForSeconds(world.levels[levelIndex].durationsAnimations[exerciseIndex]);

            AudioManager.AudioManager.Instance.PlusEnvironmentVolume(world.levels[levelIndex].levelName);
            SetExerciseText();
            nextLevelCount++;
            levelUiManager.ShowUI(true, nextLevelCount, levelIndex);
        }
        else
        {
            Debug.Log("Bad");
            AudioManager.AudioManager.Instance.Play("Lose");
        }
    }
}
