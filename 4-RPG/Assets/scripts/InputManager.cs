#region USING
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
#endregion
public class InputManager : MonoBehaviour
{
    #region STAT CHANGES
    public void changeName()
    {
        string pName = EnterName.GetComponent<TMP_InputField>().text;
        Game.GetComponent<GameManager>().setPlayerName(pName);
        TextPrefab.GetComponent<TextMeshProUGUI>().text = $"Name:{pName}";
    }
    #endregion

    #region INPUTS
    private void GetInput()
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
    #endregion
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

    #region DEFAULT
    private void Start()
    {
        Game = GameObject.Find("Game");
        Menu.enabled = false;
        string pName = Game.GetComponent<GameManager>().getPlayerName();
        TextPrefab.GetComponent<TextMeshProUGUI>().text = $"Name:{pName}";

        mainCam.enabled = true;
        mapCam.enabled = false;
    }
    void Update()
    {
        GetInput();
    }
    #endregion

}
