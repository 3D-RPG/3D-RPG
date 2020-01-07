using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject UI;
    
    public void OnClick()
    {
        switch (transform.name)
        {
            case "New Game":
                Debug.Log("New Game");
                break;

            case "Load Game":
                Debug.Log("Load Game");
                break;

            case "Settings":
                UI.SetActive(true);
                break;

            default:
                break;
        }
    }
}