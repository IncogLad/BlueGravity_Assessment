using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ChestEquipment", menuName = "ScriptableObjects/ChestEquipment")]
public class ChestEquipment : ScriptableObject
{
    public int id;

    [Header("UI Elements")]
    public string name;
    public int cost;
    public ItemType itemType;
    public Sprite iconSprite;

    [Header("Player Equipment Elements")]
    public Sprite torsoSprite;
    public Sprite pelvisSprite;

}
