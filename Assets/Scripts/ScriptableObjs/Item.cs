using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType { Consumable, Hood, Gloves, Chest, Boots}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    private string name;
    private int cost;
    private ItemType itemType;


    private Sprite iconSprite;
    private Sprite equipmentSprite;

}
