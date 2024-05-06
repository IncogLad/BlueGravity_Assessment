using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LegEquipment", menuName = "ScriptableObjects/LegEquipment")]
public class LegEquipment : ScriptableObject
{
    public int id;

    [Header("UI Elements")]
    public string name;
    public int cost;
    public ItemType itemType;
    public Sprite iconSprite;

    [Header("Player Equipment Elements")]
    public Sprite leftLegSprite;
    public Sprite rightLegSprite;

    public Sprite leftBootSprite;
    public Sprite rightBootSprite;

}
