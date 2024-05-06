using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmationPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI confirmationText;
    [SerializeField] private TextMeshProUGUI warningText;

    public void ItemConfirmation(string itemName)
    {
        gameObject.SetActive(true);
        confirmationText.text = "Buy " + itemName + "?";

    }

}
