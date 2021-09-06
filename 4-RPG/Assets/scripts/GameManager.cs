using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string playerName;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private LayerMask layer;
    public bool paused;

    public void setPlayerName(string name) { playerName = name; }
    public string getPlayerName() { return playerName; }

    private void Start()
    {
        Player = GameObject.Find("Player");
        paused = false;
    }

    private void Update()
    {
        GetPlayerTargetPos();
    }

    public void FlipInputState()
    {
        if (Player.GetComponent<PlayerController>().enabled == false && paused == false)
        {
            Player.GetComponent<PlayerController>().enabled = true;
            paused = true;
        }
        else
        {
            Player.GetComponent<PlayerController>().enabled = false;
            paused = true;
        }
    }


    public void GetPlayerTargetPos()
    {
        if (!paused)
        {
            //TODO: Check for enemies/gameobjects
            if (Input.GetMouseButton(1))
            {
                Debug.Log("m1 clicked");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layer);
                if (hit.collider != null)
                {
                    Debug.Log("collider not null");
                    Player.GetComponent<PlayerController>().GetPath(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                else
                {
                    Debug.Log("collider null");
                }
            }
        }
    }
}
