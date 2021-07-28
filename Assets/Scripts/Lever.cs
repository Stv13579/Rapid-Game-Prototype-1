using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public GameObject[] toggleObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ToggleLever();
        }
    }

    public void ToggleLever() //Toggles whatever the lever is connected to.
    {
        foreach (GameObject toggleObject in toggleObjects)
        {
            if (toggleObject.CompareTag("Toggleable"))
            {
                toggleObject.GetComponent<LightScript>().LightToggle();
            }
        }

    }
}
