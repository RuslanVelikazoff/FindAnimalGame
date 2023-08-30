using System.Collections;
using UnityEngine;

namespace Loader
{
    public class LevelLoader : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private UI.LevelUIManager levelUiManager;
        [SerializeField] private Loader.LoadScreen loadScreen;
        private Animation.UIAnimation UIAnimation;

        [Space(7)]

        [Header("Level manager")]
        [SerializeField] private LevelManager levelManager;

        [Space(7)]
        [Header("Animations")]
        [SerializeField] private Animation.AnimalAnimations[] animalAnimations;

        private IEnumerator Start()
        {
            for (int i = 0; i < animalAnimations.Length; i++)
            {
                animalAnimations[i].Initialize();
            }

            levelUiManager.Initialize(levelManager);
            levelManager.Initialize(levelUiManager, animalAnimations);

            UIAnimation = new Animation.UIAnimation();
            loadScreen.Initialize(UIAnimation);

            yield return new WaitForSeconds(1.5f);

            loadScreen.CloseLoadPanel();
        }
    }
}
