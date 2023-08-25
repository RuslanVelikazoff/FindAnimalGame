using UnityEngine;
using System.Collections;

public class FullGameButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Initialize()
    {
        if (this.gameObject.active)
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
