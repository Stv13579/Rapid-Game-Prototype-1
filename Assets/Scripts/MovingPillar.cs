using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPillar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform pillar;
    private BoxCollider2D boxCol;
    public bool down = false;
    void Start()
    {
        pillar = this.transform.GetChild(0);
        boxCol = pillar.gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pillar.localPosition.y > -0.64f && down)
        {
            pillar.localPosition += new Vector3(0.0f, -0.001f, 0.0f);
            boxCol.size += new Vector2(0.0f, -0.001f);
            boxCol.offset += new Vector2(0.0f, 0.0005f);

        }
        else if (pillar.localPosition.y < 0.0f && !down)
        {
            pillar.localPosition += new Vector3(0.0f, 0.001f, 0.0f);
            boxCol.size += new Vector2(0.0f, 0.001f);
            boxCol.offset += new Vector2(0.0f, -0.0005f);
        }


    }

    public void movePillar()
    {
        down = !down;
    }
}
