using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] toggleObjects;
    private int active = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //Toggles whatever the pressure plate is connected to
    {
        if(active == 0)
        {
            foreach (GameObject toggleObject in toggleObjects)
            {
                if (toggleObject.GetComponent<LightScript>())
                {
                    toggleObject.GetComponent<LightScript>().LightToggle();
                }
            }
        }

        active += 1;
    }

    private void OnTriggerExit2D(Collider2D collision) //Toggles whatever the pressure plate is connected to
    {
        if (active == 1)
        {
            foreach (GameObject toggleObject in toggleObjects)
            {
                if (toggleObject.GetComponent<LightScript>())
                {
                    toggleObject.GetComponent<LightScript>().LightToggle();
                }
            }
        }
        active -= 1;

    }
}
