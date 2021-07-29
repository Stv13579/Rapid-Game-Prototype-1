using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public GameObject[] toggleObjects;
    public Sprite[] sprites;
    private int spriteIndex = 0;

    private bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
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
        spriteIndex += 1;
        spriteIndex %= 2;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
