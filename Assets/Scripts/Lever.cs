using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public GameObject[] toggleObjects;

    private bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && inRange)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
        Debug.Log("Test");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
