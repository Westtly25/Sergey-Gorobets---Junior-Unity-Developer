using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Code.Runtime.Logic.UI_Components
{
    public class CustomProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Image progress;

        [SerializeField]
        private TextMeshProUGUI valueText;

        private void Awake()
        {
            progress = GetComponent<Image>();
            valueText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Change(float value)
        {
            progress.fillAmount = value;
            valueText.text = value.ToString();
        }
    }
}