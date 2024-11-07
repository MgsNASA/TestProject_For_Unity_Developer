using System;
using System.Collections.Generic;
using CodeBase.Models;
using CodeBase.Views;
using UnityEngine;

namespace CodeBase.Controllers
{
    public class StartWindowController : BaseController
    {
        public StartWindowView view;
        public StartWindowModel model;
        public ShopWindowController shopWindowController;

        private int currentItemCount; // Поле для хранения значения itemCount

        private void Awake()
        {
            Initialize(model, view);
        }

        public override void Initialize(BaseModel model, BaseView view)
        {
            this.model = model as StartWindowModel;
            this.view = view as StartWindowView;

            // Подписываемся на события представления
            this.view.OnItemCountChanged += HandleItemCountChanged;
            this.view.OnOpenShopButtonClicked += HandleOpenShopButtonClicked;
            Debug.Log("StartWindowController: Подписка на события завершена");
        }

        public override void HandleUserInput(object input)
        {
            // Дополнительная обработка пользовательского ввода
        }

        private void HandleItemCountChanged(int itemCount)
        {
            currentItemCount = itemCount; // Обновляем текущее значение itemCount
            model.ItemCount = itemCount;  // Обновляем значение в модели, если нужно
            Debug.Log("ItemCount изменен на: " + itemCount);
        }

        private void HandleOpenShopButtonClicked()
        {
            // Используем currentItemCount вместо model.ItemCount для передачи точного значения
            var defaultItems = model.DefaultShopData.items; // Предметы по умолчанию из ScriptableObject

            // Устанавливаем предметы в модели с учетом currentItemCount
            model.SetItems(defaultItems, currentItemCount);

            // Передаем данные в ShopWindowController
            shopWindowController.OpenWindow(
                model.DefaultShopData.title,
                model.DefaultShopData.description,
                model.GetItems(), // Вызываем GetItems
                model.DefaultShopData.price,
                model.DefaultShopData.discount,
                model.DefaultShopData.mainIconName
            );

            // Отключаем или скрываем StartWindow
            model.gameObject.SetActive(false);
            view.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
