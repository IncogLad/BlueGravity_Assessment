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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
