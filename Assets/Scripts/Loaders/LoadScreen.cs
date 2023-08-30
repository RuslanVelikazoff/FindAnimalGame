using UnityEngine;
using UnityEngine.UI;

namespace Loader
{
    public class LoadScreen : MonoBehaviour
    {
        [Header("Панели")]
        [SerializeField] private GameObject loadPanel;
        [SerializeField] private GameObject mainPanel;

        [Header("Дополнительные компоненты")]
        private Animation.UIAnimation UIAnimation;

        public void Initialize(Animation.UIAnimation uIAnimation)
        {
            UIAnimation = uIAnimation;
        }

        public void CloseLoadPanel()
        {
            UIAnimation.OpenPanel(loadPanel, mainPanel);
        }

        public void OpenLoadPanel()
        {
            UIAnimation.OpenPanel(mainPanel, loadPanel);
        }
    }
}
