using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private bool doorOpened;

    private void Start()
    {
        doorOpened = false;
    }
    public void OpenDoor()
    {
        if (!doorOpened)
        {
            transform.Translate(0, 8, 0);
            doorOpened = true;
        }
    }
    public void CloseDoor()
    {
        transform.Translate(0, -8, 0);
    }

}
