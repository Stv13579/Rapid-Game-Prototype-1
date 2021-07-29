using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

    }

    public void DoorOpen()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
