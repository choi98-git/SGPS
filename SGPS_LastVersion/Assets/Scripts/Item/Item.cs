using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ITem", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType; // 아이템 종류
    public Sprite itemImage;
    public GameObject itemPrefab;

    public string weaponType; // 무기 종류

    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC
    }


}
