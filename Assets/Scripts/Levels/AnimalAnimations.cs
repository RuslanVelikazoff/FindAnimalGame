using System.Collections;
using UnityEngine;

namespace Animation
{
    public class AnimalAnimations : MonoBehaviour
    {
        private Animator animator;

        public void Initialize()
        {
            animator = gameObject.GetComponent<Animator>();
        }
        
        public void StartAnimation(float duration) 
        {
            StartCoroutine(StartAnimationCO(duration));
        }

        private IEnumerator StartAnimationCO(float duration)
        {
            AudioManager.AudioManager.Instance.Play(this.gameObject.name);
            animator.SetBool("Anim", true);

            yield return new WaitForSeconds(duration);
            
            animator.SetBool("Anim", false);
        }
    }
}
