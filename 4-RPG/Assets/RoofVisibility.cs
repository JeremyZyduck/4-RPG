using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofVisibility : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = new Color (1,1,1, 0.5f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        }
    }
}
