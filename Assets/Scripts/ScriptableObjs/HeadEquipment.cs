using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HeadEquipment", menuName = "ScriptableObjects/HeadEquipment")]
public class HeadEquipment : ScriptableObject
{
    public int id;

    [Header("UI Elements")]
    public string name;
    public int cost;
    public ItemType itemType;
    public Sprite iconSprite;

    [Header("Player Equipment Elements")]
    public Sprite hoodSprite;
    public Sprite maskSprite;

}
