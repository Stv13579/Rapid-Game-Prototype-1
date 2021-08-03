using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLever : MonoBehaviour
{
    public GameObject[] Levers;
    public GameObject[] Pillars;

    public bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && inRange)
        {
            ToggleLever();
        }
    }

    public void ToggleLever() //Toggles whatever the lever is connected to.
    {
        foreach (GameObject lever in Levers)
        {
            lever.GetComponent<Lever>().spriteIndex = 0;
            lever.gameObject.GetComponent<SpriteRenderer>().sprite = lever.GetComponent<Lever>().sprites[0];
        }
        foreach (GameObject pillar in Pillars)
        {
            pillar.GetComponent<MovingPillar>().direction = -1.0f;
        }

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
