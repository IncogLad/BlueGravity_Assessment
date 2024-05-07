using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCShopkeeper : MonoBehaviour
{
    [SerializeField] private GameObject interactButton;
    [SerializeField] private GameObject msgText;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        interactButton.SetActive(false);
    }
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            interactButton.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            if (Input.GetKey(KeyCode.E) && interactButton.activeSelf)
            {
                shop.SetActive(true);
                inventory.SetActive(true);
                interactButton.SetActive(false);
                msgText.SetActive(true);
                AudioManager.Instance.PlayAudio(SoundEffect.NOTIF);
            }

            
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            interactButton.SetActive(false);
            shop.SetActive(false);
            inventory.SetActive(false);
            msgText.SetActive(false);
        }
    }

    
}
