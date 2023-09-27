using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Code.Runtime.Logic.UI_Components
{
    public class CustomProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Image progress;

        private void Awake()
        {
            progress = progress != null ?
                progress : GetComponentInChildren<Image>();
        }

        public void Change(float value) =>
            progress.fillAmount = value;
    }
}