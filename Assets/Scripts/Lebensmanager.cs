using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lebensmanager : MonoBehaviour
{
    [SerializeField]
    private int playerHp = 10;
    [SerializeField]
    private GameObject newStartCanvas;
    private static Lebensmanager instance;
    public bool PlayerAlive
    {
        get
        {
            return playerHp > 0;
        }

    }
    public static Lebensmanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Lebensmanager> ();
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    public void DecreaseLife ()
    {
        playerHp -= 1;
        Debug.Log ("PLaer hp" + playerHp);
        if (!PlayerAlive)
        {
            ShowCanvas (true);
        }
    }
    public void SetLife (int hp)
    {
        playerHp = hp;
    }
    public void ShowCanvas (bool show)
    {
        newStartCanvas.SetActive (show);
    }
}