using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool OpenDoor;
    // Update is called once per frame
    void Update()
    {
        if ()
        {
           
        }
    }

    public void DoorOpen()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;


    }
}
