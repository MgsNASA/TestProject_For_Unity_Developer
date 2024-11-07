using CodeBase.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace CodeBase.Views
{
    public class ShopWindowView : BaseView
    {
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI descriptionText;
        public Transform itemsParent;
        public TextMeshProUGUI priceText;
        public Image mainIcon;

        public GameObject itemPrefab; // Ссылка на Prefab предмета

        public override void OnUserInteraction()
        {
            // Реализация взаимодействия с пользователем, если нужно
        }

        public override void UpdateView(BaseModel baseModel)
        {
            ShopWindowModel model = baseModel as ShopWindowModel;
            if (model == null)
                return;

            titleText.text = model.GetTitle();
            descriptionText.text = model.GetDescription();
            priceText.text = model.GetFinalPrice().ToString("F2");
            mainIcon.sprite = GetIcon(model.GetMainIconName());
            UpdateItems(model.GetItems());
        }

        private void UpdateItems(List<ItemData> items)
        {
            // Удаляем предыдущие элементы из itemsParent
            foreach (Transform child in itemsParent)
            {
                Destroy(child.gameObject);
            }

            // Создаем новые элементы на основе данных
            foreach (var item in items)
            {
                GameObject itemUI = Instantiate(itemPrefab, itemsParent);
                var iconImage = itemUI.transform.Find("Icon").GetComponent<Image>();
                var quantityText = itemUI.transform.Find("QuantityText").GetComponent<TextMeshProUGUI>();
                iconImage.sprite = item.itemIcon; // Устанавливаем спрайт из ItemData
                quantityText.text = item.quantity.ToString();
            }
        }

        private Sprite GetIcon(string iconName)
        {
            // Логика для получения спрайта по имени, если потребуется
            return null;
        }
    }
}
