using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    public List<ArmEquipment> armEquipmentList = new List<ArmEquipment>();
    public List<HeadEquipment> headEquipmentList = new List<HeadEquipment>();
    public List<ChestEquipment> chestEquipmentList = new List<ChestEquipment>();
    public List<LegEquipment> legEquipmentList = new List<LegEquipment>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }
    
}
