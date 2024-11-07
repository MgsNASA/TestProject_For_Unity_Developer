using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ShopWindowData", menuName = "ScriptableObjects/ShopWindowData", order = 1)]
public class ShopWindowData : ScriptableObject
{
    public string title;
    public string description;
    public List<ItemData> items;
    public float price;
    public float discount;
    public string mainIconName;
    public Sprite mainIcon;
}