using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerControllable
{
    void Move(Vector3 direction);

    void Interact();

    void Attack();


}
