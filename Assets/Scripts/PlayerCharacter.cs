using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IPlayerControllable
{
    [SerializeField] private float movementSpeed = 1.5f;


    void Start()
    {
        
    }

    void Update()
    {
        
        MovementInput();
    }

    public void Move(Vector3 direction)
    {
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
        }
        if (y_axisValue < 0)
        {
            Move(Vector3.down);
        }
        if (x_axisValue > 0)
        {
            Move(Vector3.right);
        }
    
        
    }

}
