using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

namespace Animation
{
    public class UIAnimation
    {
        private const float animationPanelDuration = 1f;

        private const float animationClickDuration = .3f;
        private Vector3 animationClickScale = new Vector3(.9f, .9f, .9f);
        private Vector3 standartClickScale = new Vector3(1, 1, 1);

        private const float animationClearDuration = 1.3f;

        private Vector3 positionLoadScreen = new Vector3(0, 18.31f, 90f);
        private const float animationLoadDuration = 1.5f;

        public void OpenPanel(GameObject currentPanel, GameObject newPanel)
        {
            Sequence sequence = DOTween.Sequence();

            Vector3 currentPosition = currentPanel.transform.position;
            Vector3 newPosition = newPanel.transform.position;

            sequence.Append(currentPanel.transform.DOMove(newPosition, animationPanelDuration))
                .Join(newPanel.transform.DOMove(currentPosition, animationPanelDuration));
        }

        public void ClickAnimation(Button button)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(button.transform.DOScale(animationClickScale, animationClickDuration))
                .Append(button.transform.DOScale(standartClickScale, animationClickDuration));

        }

        public IEnumerator ClearButtonAnimationCO(Button clearButton, Text yearText)
        {
            clearButton.GetComponent<Animator>().SetBool("Anim", true);

            yield return new WaitForSeconds(animationClearDuration);

            yearText.text = "";
            clearButton.GetComponent<Animator>().SetBool("Anim", false);
        }
    }
}
