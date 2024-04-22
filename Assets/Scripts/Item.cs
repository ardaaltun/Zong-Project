using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "NewItem/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int itemQuantity;
}