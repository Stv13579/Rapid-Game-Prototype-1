using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGrab : MonoBehaviour
{
    public bool inRange;
    private HingeJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && inRange && joint == null)
        {
            joint = this.gameObject.AddComponent<HingeJoint2D>();//new HingeJoint2D();
            joint.connectedBody = GameObject.Find("Character").GetComponent<Rigidbody2D>();
            this.gameObject.GetComponent<Rigidbody2D>().mass = 1;
               this.GetComponent<AudioSource>().Play();
            
        }
        else if (Input.GetKeyDown("e") && joint != null)
        {  this.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Rigidbody2D>().mass = 10;
            Destroy(joint);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;  
            this.GetComponent<AudioSource>().Play();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
        
       //  this.GetComponent<AudioSource>().Stop();
    }
    
}
