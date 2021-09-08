using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private Camera mapCam;
    [SerializeField]
    private GameObject Game;

    [SerializeField]
    private GameObject TextPrefab;
    [SerializeField]
    private GameObject EnterName;
    [SerializeField]
    private Canvas Menu;

    bool mapIsOn
    {
        get
        {
            return mapCam.enabled;
        }
    }

    private void Start()
    {
        Game = GameObject.Find("Game");
        Menu.enabled = false;
        string pName = Game.GetComponent<GameManager>().getPlayerName();
        TextPrefab.GetComponent<TextMeshProUGUI>().text = $"Name:{pName}";

        mainCam.enabled = true;
        mapCam.enabled = false;
        Game = GameObject.Find("Game");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !Menu.enabled)
        {
            if (mapIsOn)
            {
                //mainCam.enabled = true;
                mapCam.enabled = false;
            }
            else
            {
                //mainCam.enabled = false;
                mapCam.enabled = true;
            }
            Game.GetComponent<GameManager>().FlipInputState();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !mapIsOn)
        {
            if (Menu.enabled)
            {
                Menu.enabled = false;
            }
            else
            {
                Menu.enabled = true;
            }
            Game.GetComponent<GameManager>().FlipInputState();
        }
    }

    public void changeName()
    {
        string pName = EnterName.GetComponent<TMP_InputField>().text;
        Game.GetComponent<GameManager>().setPlayerName(pName);
        TextPrefab.GetComponent<TextMeshProUGUI>().text = $"Name:{pName}";
    }
}
