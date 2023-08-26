using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private UI.LevelUIManager levelUiManager;
    
    [Space(7)]
    
    [Header("Camera scaller")]
    [SerializeField] private CameraScaller cameraScaller;

    [Space(7)]
    
    [Header("Level manager")] 
    [SerializeField] private LevelManager levelManager;

    [Space(7)] [Header("Animations")] 
    [SerializeField] private Animation.AnimalAnimations[] animalAnimations;
    
    private void Start()
    {
        cameraScaller.Initialize();
        
        for (int i = 0; i < animalAnimations.Length; i++)
        {
            animalAnimations[i].Initialize();
        }
        
        levelUiManager.Initialize(levelManager);
        levelManager.Initialize(levelUiManager, animalAnimations);
    }
}
