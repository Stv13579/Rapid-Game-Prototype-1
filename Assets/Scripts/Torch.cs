using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{


    public bool inRange = false;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        if (active == true)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && inRange)
        {

            activate();

            this.gameObject.transform.GetChild(1).gameObject.GetComponent<Light>().enabled = true;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //on = true;
            this.GetComponent<AudioSource>().Play();

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

    public void activate()
    {
        this.gameObject.transform.GetChild(1).gameObject.GetComponent<Light>().enabled = true;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        active = true;
    }
}
