using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<BoxCollider2D>().size = this.gameObject.GetComponent<SpriteRenderer>().size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
