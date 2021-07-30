using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] toggleObjects;
    private int active = 0;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];

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
                else if (toggleObject.GetComponent<MovingPillar>())
                {
                    toggleObject.GetComponent<MovingPillar>().movePillar();
                }
                else if (toggleObject.GetComponent<Doors>())
                {
                    toggleObject.GetComponent<Doors>().DoorToggle();
                }
            }
        }

        active += 1;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
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
                else if (toggleObject.GetComponent<MovingPillar>())
                {
                    toggleObject.GetComponent<MovingPillar>().movePillar();
                }
                else if (toggleObject.GetComponent<Doors>())
                {
                    toggleObject.GetComponent<Doors>().DoorToggle();
                }
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        active -= 1;


    }
}
