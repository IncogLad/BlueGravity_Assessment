using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSkeleton : MonoBehaviour
{
    [Header("Head Equipment Renderers")]
    [SerializeField] private SpriteRenderer hoodRenderer;
    [SerializeField] private SpriteRenderer maskRenderer;

    [Header("Chest Equipment Renderers")]
    [SerializeField] private SpriteRenderer torsoRenderer;
    [SerializeField] private SpriteRenderer pelvisRenderer;

    [Header("Arm Equipment Renderers")]
    [SerializeField] private SpriteRenderer leftShoulderRenderer;
    [SerializeField] private SpriteRenderer leftArmRenderer;
    [SerializeField] private SpriteRenderer leftGlovesRenderer;
    [SerializeField] private SpriteRenderer rightShoulderRenderer;
    [SerializeField] private SpriteRenderer rightArmRenderer;
    [SerializeField] private SpriteRenderer rightGlovesRenderer;

    [Header("Leg Equipment Renderers")]
    [SerializeField] private SpriteRenderer leftLegRenderer;
    [SerializeField] private SpriteRenderer leftBootRenderer;
    [SerializeField] private SpriteRenderer rightLegRenderer;
    [SerializeField] private SpriteRenderer rightBootRenderer;

    [Header("Default Equipment")]
    private Sprite hoodDef;
    private Sprite maskDef;
    private Sprite torsoDef;
    private Sprite pelvisDef;
    private Sprite leftShoulderDef;
    private Sprite leftArmDef;
    private Sprite leftGlovesDef;
    private Sprite rightShoulderDef;
    private Sprite rightArmDef;
    private Sprite rightGlovesDef;
    private Sprite leftLegDef;
    private Sprite leftBootDef;
    private Sprite rightLegDef;
    private Sprite rightBootDef;

    void Start()
    {
        hoodDef = hoodRenderer.sprite;
        maskDef = maskRenderer.sprite;

        torsoDef = torsoRenderer.sprite;
        pelvisDef = pelvisRenderer.sprite;

        leftLegDef = leftBootRenderer.sprite;
        leftBootDef = leftLegRenderer.sprite;
        rightLegDef = rightBootRenderer.sprite;
        rightBootDef = rightLegRenderer.sprite;

        leftShoulderDef = leftShoulderRenderer.sprite;
        leftArmDef = leftArmRenderer.sprite;
        leftGlovesDef = leftGlovesRenderer.sprite;
        rightShoulderDef = rightShoulderRenderer.sprite;
        rightArmDef = rightArmRenderer.sprite;
        rightGlovesDef = rightGlovesRenderer.sprite;
    }

    public void UpdateEquipment(ItemType type, int equipId)
    {
        EquipmentManager em = EquipmentManager.Instance;
        if (equipId < 0)
        {
            switch (type)
            {
                case ItemType.Boots:
                    leftBootRenderer.sprite = leftLegDef; 
                    leftLegRenderer.sprite = leftBootDef;
                    rightBootRenderer.sprite = rightLegDef;
                    rightLegRenderer.sprite = rightBootDef;
                    break;
                case ItemType.Hood:
                    hoodRenderer.sprite = hoodDef;
                    maskRenderer.sprite = maskDef;
                    break;
                case ItemType.Chest:
                    torsoRenderer.sprite = torsoDef;
                    pelvisRenderer.sprite = pelvisDef;
                    break;
                case ItemType.Gloves:
                    leftShoulderRenderer.sprite = leftShoulderDef;
                    leftArmRenderer.sprite = leftArmDef;
                    leftGlovesRenderer.sprite = leftGlovesDef;
                    rightShoulderRenderer.sprite = rightShoulderDef;
                    rightArmRenderer.sprite = rightArmDef;
                    rightGlovesRenderer.sprite = rightGlovesDef;
                    break;
            }
        }
        else
        {
            switch (type)
            {
                case ItemType.Boots:
                    leftBootRenderer.sprite = em.legEquipmentList[equipId].leftBootSprite;
                    leftLegRenderer.sprite = em.legEquipmentList[equipId].leftLegSprite;
                    rightBootRenderer.sprite = em.legEquipmentList[equipId].rightBootSprite;
                    rightLegRenderer.sprite = em.legEquipmentList[equipId].rightLegSprite;
                    break;
                case ItemType.Hood:
                    hoodRenderer.sprite = em.headEquipmentList[equipId].hoodSprite;
                    maskRenderer.sprite = em.headEquipmentList[equipId].maskSprite;
                    break;
                case ItemType.Chest:
                    torsoRenderer.sprite = em.chestEquipmentList[equipId].torsoSprite;
                    pelvisRenderer.sprite = em.chestEquipmentList[equipId].pelvisSprite;
                    break;
                case ItemType.Gloves:
                    leftShoulderRenderer.sprite = em.armEquipmentList[equipId].leftShoulderSprite;
                    leftArmRenderer.sprite = em.armEquipmentList[equipId].leftArmSprite;
                    leftGlovesRenderer.sprite = em.armEquipmentList[equipId].leftGloveSprite;
                    rightShoulderRenderer.sprite = em.armEquipmentList[equipId].rightShoulderSprite;
                    rightArmRenderer.sprite = em.armEquipmentList[equipId].rightArmSprite;
                    rightGlovesRenderer.sprite = em.armEquipmentList[equipId].rightGloveSprite;
                    break;
            }
        }
        
    }

}
