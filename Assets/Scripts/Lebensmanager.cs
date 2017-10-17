using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebensmanager : MonoBehaviour {
    [SerializeField]
    private int playerHp = 10;
    
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
       

    }
    public void SetPHp ()
    {
        playerHp -= 1;
        Debug.Log ("PLaer hp"+playerHp);
        if (playerHp <= 0)
        {
            Debug.Log("Du bist tot");
        }
    }
}