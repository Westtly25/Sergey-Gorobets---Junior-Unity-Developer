using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Weapons
{
    public class ItemConfig : ScriptableObject
    {
        [Header("Base Data")]
        [SerializeField, TextArea(2, 4)]
        private string title;
        [SerializeField]
        private Sprite icon;

        public string Title => title;
        public Sprite Icon => icon;
    }
}