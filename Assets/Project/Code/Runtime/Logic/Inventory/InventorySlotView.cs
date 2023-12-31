﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Code.Runtime.Logic.Inventory
{
    public sealed class InventorySlotView : MonoBehaviour
    {
        [SerializeField]
        private int id;
        [SerializeField]
        private Image iconImage;
        [SerializeField]
        private TextMeshProUGUI ammoText;

        public int Id => id;

        private void Awake()
        {
            iconImage = GetComponent<Image>();
            ammoText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetData(Sprite icon) =>
            iconImage.sprite = icon;

        public void SetData(int ammoStock) =>
           ammoText.text = ammoStock.ToString();

        public void SetData(Sprite icon, int ammo)
        {
            iconImage.sprite = icon;
            ammoText.text = ammo.ToString();
        }
    }
}