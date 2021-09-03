using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x, mousePos.y);
            if (Input.GetButtonDown("Fire1"))
            {
                //TODO: CHANGE COLOR
            }
            if (Input.GetButtonDown("Fire2"))
            {
                //TODO: CHANGE COLOR
            }
        }
        catch
        { 
        //TODO: DISABLE CURSOR
        }
        
    }
}
