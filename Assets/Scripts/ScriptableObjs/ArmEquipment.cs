using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ArmEquipment", menuName = "ScriptableObjects/ArmEquipment")]
public class ArmEquipment : ScriptableObject
{
    public int id;

    [Header("UI Elements")]
    public string name;
    public int cost;
    public ItemType itemType;
    public Sprite iconSprite;

    [Header("Player Equipment Elements")]
    public Sprite leftShoulderSprite;
    public Sprite rightShoulderSprite;

    public Sprite leftArmSprite;
    public Sprite rightArmSprite;

    public Sprite leftGloveSprite;
    public Sprite rightGloveSprite;

}
