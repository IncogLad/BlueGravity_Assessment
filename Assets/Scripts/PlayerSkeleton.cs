using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
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
    

}
