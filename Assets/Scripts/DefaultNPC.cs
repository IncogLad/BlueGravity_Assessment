using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultNPC : MonoBehaviour
{
    [SerializeField] private GameObject interactButton;
    [SerializeField] private GameObject msgText;

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
            msgText.SetActive(false);
        }
    }

}
