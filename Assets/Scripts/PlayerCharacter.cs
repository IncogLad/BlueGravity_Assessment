using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IPlayerControllable
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private PlayerSkeleton skeleton;

    void Update()
    {
        if (GameManager.Instance.isPaused)
        { return; }


        MovementInput();
    }

    public void Move(Vector3 direction)
    {
        skeleton.gameObject.GetComponent<Animator>().Play("Rogue_run_01");
        Vector3.Normalize(direction);
        gameObject.transform.position += (direction * movementSpeed * Time.deltaTime);
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    private void MovementInput()
    {
        float x_axisValue = Input.GetAxis("Horizontal");
        float y_axisValue = Input.GetAxis("Vertical");
        

        if (y_axisValue > 0)
        {
            Move(Vector3.up);
        }
        if (x_axisValue < 0)
        {
            Move(Vector3.left);
            if (skeleton.gameObject.transform.localScale.x >= 0)
                skeleton.gameObject.transform.localScale = new Vector3(-skeleton.gameObject.transform.localScale.x, skeleton.gameObject.transform.localScale.y, skeleton.gameObject.transform.localScale.z);
        }
        if (y_axisValue < 0)
        {
            Move(Vector3.down);
        }
        if (x_axisValue > 0)
        {
            Move(Vector3.right);
            if (skeleton.gameObject.transform.localScale.x < 0)
                skeleton.gameObject.transform.localScale = new Vector3(-skeleton.gameObject.transform.localScale.x, skeleton.gameObject.transform.localScale.y, skeleton.gameObject.transform.localScale.z);
        }

        if (y_axisValue == 0 && x_axisValue == 0)
        {
            skeleton.gameObject.GetComponent<Animator>().Play("Rogue_idle_01");
        }
    }

}
