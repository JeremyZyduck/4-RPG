#region USING
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
#endregion
/*<SUMMARY>
 *Gets users keyboard inputs and 
<USE>
 *Game Object.
</USE>
</SUMMARY>*/
public class InputManager : MonoBehaviour
{
    #region TODO
    #endregion
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
        InputGUI();
        GetPlayerTargetPos();
    }
    #region GUI INPUT
    private void InputGUI()
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
        else if (Input.GetKeyDown(KeyCode.Escape) && !mapIsOn)
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
    #region PLAYERMOVE
    [SerializeField]
    private LayerMask layer;
    public void GetPlayerTargetPos()
    {
        if (!GameObject.Find("Game").GetComponent<GameManager>().paused)
        {
            //TODO: Check for enemies/game objects
            if (Input.GetMouseButton(1))
            {
                Debug.Log("m1 clicked");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layer);
                if (hit.collider != null)
                {
                    Debug.Log("collider not null");
                    GameObject.Find("Player").GetComponent<PlayerController>().GetPath(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    GameObject.Find("Player").GetComponent<PlayerController>().AnimationState = 1;
                }
                else
                {
                    Debug.Log("collider null");
                }
            }
        }
    }
    #endregion
    #endregion
    #region MAP/CAMERA
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private Camera mapCam;
    bool mapIsOn
    {
        get
        {
            return mapCam.enabled;
        }
    }
    #endregion
    #region GUI
    [SerializeField]
    private GameObject TextPrefab;
    [SerializeField]
    private GameObject EnterName;
    [SerializeField]
    private Canvas Menu;
    #endregion
    #region DEFAULT
    [SerializeField]
    private GameObject Game;

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
