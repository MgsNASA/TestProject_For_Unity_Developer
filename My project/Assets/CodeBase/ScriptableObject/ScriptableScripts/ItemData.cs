using UnityEngine;

[CreateAssetMenu ( fileName = "ItemData" , menuName = "Item Data" )]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int quantity;
}
