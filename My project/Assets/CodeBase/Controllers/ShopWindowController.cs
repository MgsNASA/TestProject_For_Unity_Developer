using System.Collections.Generic;
using CodeBase.Models;
using CodeBase.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Controllers
{
    public class ShopWindowController : MonoBehaviour
    {
        [FormerlySerializedAs("model")] [SerializeField]
        private ShopWindowModel _shopWindowModel;
        [FormerlySerializedAs("view")] [SerializeField]
        private ShopWindowView _shopWindowView;

        public void Initialize(ShopWindowModel model, ShopWindowView view)
        {
            this._shopWindowModel = model;
            this._shopWindowView = view;
        }

        public void OpenWindow(string title, string description, List<ItemData> items, float price, float discount, string mainIconName)
        {
            _shopWindowModel.SetTitle(title);
            _shopWindowModel.SetDescription(description);
            _shopWindowModel.SetItems(items, items.Count); // Передаем items.Count в качестве itemCount
            _shopWindowModel.SetPrice(price);
            _shopWindowModel.SetDiscount(discount);
            _shopWindowModel.SetMainIconName(mainIconName);
            _shopWindowView.gameObject.SetActive(true);
            UpdateView();
        }


        private void UpdateView()
        {
            _shopWindowView.UpdateView(_shopWindowModel);
        }
    }
}
