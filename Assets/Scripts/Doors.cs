using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private Transform doorTop;
    private Transform doorBottom;
    private BoxCollider2D doorTopCol;
    private BoxCollider2D doorBottomCol;

    private bool open = false;

    private void Start()
    {
        doorTop = this.transform.GetChild(1);
        doorBottom = this.transform.GetChild(2);

        doorTopCol = doorTop.gameObject.GetComponent<BoxCollider2D>();
        doorBottomCol = doorBottom.gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorTop.localPosition.y < 0.32f && open)
        {
            doorTop.localPosition += new Vector3(0.0f, 0.001f, 0.0f);
            doorTopCol.size += new Vector2(0.0f, -0.001f);
            doorTopCol.offset += new Vector2(0.0f, -0.0005f);

        }
        else if (doorTop.localPosition.y > 0.0f && !open)
        {
            doorTop.localPosition += new Vector3(0.0f, -0.001f, 0.0f);
            doorTopCol.size += new Vector2(0.0f, 0.001f);
            doorTopCol.offset += new Vector2(0.0f, 0.0005f);
        }

        if (doorBottom.localPosition.y > -0.32f && open)
        {
            doorBottom.localPosition += new Vector3(0.0f, -0.001f, 0.0f);
            doorBottomCol.size += new Vector2(0.0f, -0.001f);
            doorBottomCol.offset += new Vector2(0.0f, 0.0005f);

        }
        else if (doorBottom.localPosition.y < 0.0f && !open)
        {
            doorBottom.localPosition += new Vector3(0.0f, 0.001f, 0.0f);
            doorBottomCol.size += new Vector2(0.0f, 0.001f);
            doorBottomCol.offset += new Vector2(0.0f, -0.0005f);
        }
    }

    public void DoorToggle()
    {
        open = !open;
        
        if (this.transform.GetChild(3).gameObject.name == "Lock")
        {
            this.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
