using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject TextPrefab;

    [SerializeField]
    private GameObject EnterName;

    [SerializeField]
    private Canvas Menu;

    void Start()
    {
        Menu.enabled = false;
        string pName = GameObject.Find("Game").GetComponent<GameManager>().getPlayerName();
        TextPrefab.GetComponent<TextMeshProUGUI>().text = $"Name:{pName}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Menu.enabled == false)
            {
                Menu.enabled = true;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("AStar").GetComponent<AStar>().enabled = false;
            }
            else
            {
                Menu.enabled = false;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
                GameObject.Find("AStar").GetComponent<AStar>().enabled = true;
            }
        }
    }

    public void changeName()
    {
        string pName = EnterName.GetComponent<TMP_InputField>().text;
        GameObject.Find("Game").GetComponent<GameManager>().setPlayerName(pName);
        TextPrefab.GetComponent<TextMeshProUGUI>().text = $"Name:{pName}";
    }
}
