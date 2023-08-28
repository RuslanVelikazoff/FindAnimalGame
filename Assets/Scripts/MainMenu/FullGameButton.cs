using UnityEngine;
using System.Collections;

namespace Animation
{
    public class FullGameButton : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private Data.StartData data;

        public void Initialize(Data.StartData Data)
        {
            data = Data;

            if (!data._fullGame)
            {
                StartCoroutine(AnimationCO());
            }
        }

        IEnumerator AnimationCO()
        {
            _animator.SetBool("Anim", true);
            yield return new WaitForSeconds(5f);
            _animator.SetBool("Anim", false);
            yield return new WaitForSeconds(.5f);
            StartCoroutine(AnimationCO());
        }
    }
}
