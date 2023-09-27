using UnityEngine;

namespace Assets.Project.Code.Runtime.Logic.Weapons
{
    [CreateAssetMenu(fileName = "New-clip-config-so", menuName = "Shooter / Core / Weapons / Clip Config")]
    public class AmmoClipConfig : ItemConfig
    {
        [SerializeField]
        private AmmoType bulletType;
        [SerializeField, Min(10)]
        private int stock;
        [SerializeField]
        private int maxCapacity;

        public AmmoType BulletType => bulletType;
        public int Stock => stock;
        public int MaxCapacity => maxCapacity;
    }
}