using System.Collections;
using UnityEngine;

namespace Animation
{
    public class AnimalAnimations : MonoBehaviour
    {
        //TODO: пересмотреть имена животных
        private Animator animator;

        public void Initialize()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        //TODO: зебра
        public void StartAnimation(float duration) //Добавить иф елсе с именем животного
        {
            StartCoroutine(StartAnimationCO(duration));
        }

        private IEnumerator StartAnimationCO(float duration)
        {
            //TODO: добавить звуки
            animator.SetBool("Anim", true);

            yield return new WaitForSeconds(duration);
            
            animator.SetBool("Anim", false);
        }
    }
}
