using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GoldPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldAmount;

    void Start()
    {
        ResourceManager.Instance.updateGold.AddListener(UpdateGoldUI);
        UpdateGoldUI();
    }

    public void UpdateGoldUI()
    {
        goldAmount.text = ResourceManager.Instance.gold.ToString();
    }
}
