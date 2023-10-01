using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Code.Runtime.Logic.UI_Components
{
    public class CustomProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Image progress;

        public void Change(float value) =>
            progress.fillAmount = value;
    }
}