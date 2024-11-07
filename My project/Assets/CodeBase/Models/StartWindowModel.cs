using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Models
{
    public class StartWindowModel : BaseModel
    {
        [SerializeField]private ItemData selectedItem;
        [SerializeField] private ShopWindowData defaultShopData; // ScriptableObject с данными для магазина
        private List<ItemData> items; // Локальный список предметов

        private int itemCount;

        public ShopWindowData DefaultShopData => defaultShopData;

        public int ItemCount
        {
            get => itemCount;
            set => itemCount = Mathf.Clamp(value, 3, 6); // Ограничение значения от 3 до 6
        }

        // Метод SetItems для управления количеством элементов
        public void SetItems(List<ItemData> defaultItems, int itemCount)
        {
            items = new List<ItemData>();
            // Добавляем предметы в соответствии с itemCount
            for (int i = 0; i < itemCount; i++)
            {
                items.Add(selectedItem);
            }
        }

        // Метод GetItems для доступа к списку элементов
        public List<ItemData> GetItems() => items;

        public override void Initialize(params object[] parameters)
        {
            // Дополнительная логика инициализации, если необходимо
        }

        public override string GetState()
        {
            return $"ItemCount: {itemCount}, Shop Data Set: {defaultShopData != null}";
        }
    }
}