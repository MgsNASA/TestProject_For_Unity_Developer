using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Models
{
    public class ShopWindowModel : BaseModel
    {
        private string title;
        private string description;
        [SerializeField]
        private List<ItemData> items; // Динамический список предметов
        private float price;
        private float discount;
        private string mainIconName;

        public void SetItems(List<ItemData> defaultItems, int itemCount)
        {
            items = new List<ItemData>();

            // Ограничиваем itemCount, чтобы он не превышал количество доступных предметов
            itemCount = Mathf.Clamp(itemCount, 0, defaultItems.Count);

            // Добавляем предметы в соответствии с itemCount
            for (int i = 0; i < itemCount; i++)
            {
                items.Add(defaultItems[i]);
            }
        }

        public List<ItemData> GetItems() => items;

        // Остальные методы и свойства
        public void SetTitle(string newTitle) => title = newTitle;
        public void SetDescription(string newDescription) => description = newDescription;
        public void SetPrice(float newPrice) => price = newPrice;
        public void SetDiscount(float newDiscount) => discount = newDiscount;
        public void SetMainIconName(string newIconName) => mainIconName = newIconName;

        public string GetTitle() => title;
        public string GetDescription() => description;
        public float GetPrice() => price;
        public float GetDiscount() => discount;
        public string GetMainIconName() => mainIconName;

        public float GetFinalPrice() => discount > 0 ? price * (1 - discount / 100) : price;

        public override void Initialize(params object[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public override string GetState()
        {
            throw new System.NotImplementedException();
        }
    }
}