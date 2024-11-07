using System;
using CodeBase.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Views
{
    public class StartWindowView : BaseView
    {
        public TMP_InputField itemCountInput; // Поле ввода количества предметов
        public Button openShopButton; // Кнопка для открытия окна

        private const int MinItemCount = 3;
        private const int MaxItemCount = 6;

        public event Action<int> OnItemCountChanged;
        public event Action OnOpenShopButtonClicked;

        private void Start()
        {
            itemCountInput.onEndEdit.AddListener(ValidateAndNotifyItemCount);
            openShopButton.onClick.AddListener(NotifyOpenShopButtonClicked);
        }

        // Добавьте этот метод
        public void SetItemCount(int count)
        {
            itemCountInput.text = count.ToString();
        }

        public int GetItemCount()
        {
            int.TryParse(itemCountInput.text, out int count);
            return Mathf.Clamp(count, MinItemCount, MaxItemCount);
        }

        private void ValidateAndNotifyItemCount(string input)
        {
            if (int.TryParse(input, out int count))
            {
                count = Mathf.Clamp(count, MinItemCount, MaxItemCount);
                itemCountInput.text = count.ToString();
                Debug.Log("ItemCount изменен на: " + count); // Отладка
                OnItemCountChanged?.Invoke(count);
            }
            else
            {
                itemCountInput.text = MinItemCount.ToString();
                Debug.Log("ItemCount установлен на минимальное значение: " + MinItemCount); // Отладка
                OnItemCountChanged?.Invoke(MinItemCount);
            }
        }

        private void NotifyOpenShopButtonClicked()
        {
            Debug.Log("Кнопка открытия магазина нажата"); // Отладка
            OnOpenShopButtonClicked?.Invoke();
        }


        public override void UpdateView(BaseModel model)
        {
            // Не требуется в текущей реализации
        }

        public override void OnUserInteraction()
        {
            // Не требуется в текущей реализации
        }
    }
}